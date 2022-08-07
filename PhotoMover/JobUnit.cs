﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    public class JobUnit
    {
        public string SourcePath { get; set; }
        public IDateExtractor DateProvider { get; set; }
        public string CalculatedTargetPath { get; set; }
        public string RealTargetPath { get; set; }
        public JobStatus Status { get; private set; }
        public string StatusLog { get; private set; }

        private string fileName;
        private string srcFolderName;
        private string extension;
        private Config cfg;
        public JobUnit(string path)
        {
            cfg = Config.GetConfig();
            SourcePath = path;
            fileName = Path.GetFileName(path);
            srcFolderName = Path.GetDirectoryName(path);
            extension = Path.GetExtension(SourcePath);
            Status = JobStatus.NotProcessed;
            DateProvider = cfg.GetExtractorsForExt(extension).Find(p => p.IsEnabled && p.Instance != null).Instance;
            log("Job created.", false);
        }

        public void Process()
        {
            Status = JobStatus.InProgress;
            DateTime dt;
            if (!File.Exists(SourcePath))
            {
                Status = JobStatus.Error;
                log("File '" + SourcePath + "' does not exist!");
                return;
            }
            try
            {
                dt = DateProvider.GetDate(SourcePath, out string info);
                log("GetDate additional info: " + info);
            }
            catch (Exception ex) {
                log("!Failed to parse date from source file, will use file last write time. Exception msg: " + ex.Message);
                dt = DefaultInfoReader.Instance.GetDate(SourcePath, out string info);
            }

            string[] strArrayDate = new string[] { dt.Year.ToString(), dt.Month.ToString().PadLeft(2, '0'), dt.Day.ToString().PadLeft(2, '0') };
            //string strYMD = strArrayDate[0] + strArrayDate[1] + strArrayDate[2];
            string folder4CurFile = cfg.FolderStructure;
            folder4CurFile = folder4CurFile.Replace("yyyy", strArrayDate[0]);
            folder4CurFile = folder4CurFile.Replace("mm", strArrayDate[1]);
            folder4CurFile = folder4CurFile.Replace("dd", strArrayDate[2]);
            folder4CurFile = folder4CurFile.Replace("yy", strArrayDate[0].Substring(2));
            string destDirName = createFolder(cfg.TargetBasePath, folder4CurFile);

            CalculatedTargetPath = destDirName + "\\" + fileName;
            RealTargetPath = CalculatedTargetPath;
            if (File.Exists(CalculatedTargetPath))
            {
                if (cfg.TargetRule == RuleForTargetExists.skip)
                {
                    Status = JobStatus.Skipped;
                    log("Job skipped as target exists and rule set to skip");
                }
                else if (cfg.TargetRule == RuleForTargetExists.rename)
                {
                    
                    int num = 2;
                    while (num < 1000)
                    {
                        if (!File.Exists(destDirName + @"\" + fileName.Replace(extension, " (" + num.ToString() + ")" + extension)))
                        {
                            RealTargetPath = destDirName + @"\" + fileName.Replace(extension, " (" + num.ToString() + ")" + extension);
                            log("Will renamed to " + RealTargetPath);
                            break;
                        }
                        num++;
                    }
                    if (num >= 1000)
                    {
                        //num up to 1000, rename failed
                        Status = JobStatus.Error;
                        log("Rename failed after 1000 try");
                    }
                }
                else // replace, so delete existing file
                {
                    try
                    {
                        File.Delete(destDirName + @"\" + fileName);
                        log("Deleted old file in target folder before copy.");
                    }
                    catch (Exception ex)
                    {
                        log("Delete old file in target folder failed. " + ex.Message);
                        Status = JobStatus.Error;
                    }                    
                }
            }

            if(Status != JobStatus.InProgress)
            {
                return;
            }
            //dest dir name ready and status ok, now start copy or move
            if (cfg.DeleteSourceFile && (SourcePath.Substring(0, 3) == RealTargetPath.Substring(0, 3))) //same partition, move
            {
                try
                {
                    Directory.Move(SourcePath, RealTargetPath);
                    if (RealTargetPath.Equals(CalculatedTargetPath))
                        Status = JobStatus.Moved;
                    else
                        Status = JobStatus.Rename_Moved;

                    log("Move done.");
                }
                catch (Exception ex)
                {
                    log("Move file failed. " + ex.Message);
                    Status = JobStatus.Error;
                }                
            }
            else
            {
                try
                {
                    File.Copy(SourcePath, RealTargetPath);
                    if (RealTargetPath.Equals(CalculatedTargetPath))
                        Status = JobStatus.Copied;
                    else
                        Status = JobStatus.Rename_Copied;

                    log("Copy done.");
                }
                catch (Exception ex)
                {
                    log("Copy to target folder failed. " + ex.Message);
                    Status = JobStatus.Error;
                }
                
                if (cfg.DeleteSourceFile)
                {
                    try
                    {
                        File.Delete(SourcePath);
                        log("Delete source file done.");
                    }
                    catch (Exception ex)
                    {
                        Status = JobStatus.Error;
                        log("Delete source file failed. " + ex.Message);
                    }
                }
            }
        }

        public void Undo()
        {
            switch (Status)
            {
                case JobStatus.Copied:
                case JobStatus.Rename_Copied:
                    //delete target
                    try
                    {
                        File.Delete(RealTargetPath);
                        log("Undo copy done, target file deleted.");
                    }
                    catch (Exception ex)
                    {
                        log("Undo copy failed:" + ex.Message);
                    }                    
                    break;
                case JobStatus.Moved:
                case JobStatus.Rename_Moved:
                    //copy back use src name
                    try
                    {
                        File.Move(RealTargetPath, SourcePath);
                        log("Undo move done, file restored to original location.");
                    }
                    catch (Exception ex)
                    {
                        log("Undo move failed:" + ex.Message);
                    }
                    break;
                case JobStatus.Skipped:
                case JobStatus.NotProcessed:
                case JobStatus.InProgress:
                case JobStatus.Error:
                default:
                    log("Current job status not able to undo.");
                    break;
            }
        }
        public void Retry()
        {
            log("Retry process the file.");
            Process();
        }
        public void GoSrc()
        {
            if (Status == JobStatus.Moved || Status == JobStatus.Rename_Moved)
                System.Diagnostics.Process.Start("explorer.exe", "/e," + srcFolderName);
            else
                System.Diagnostics.Process.Start("explorer.exe", "/select," + SourcePath);
        }
        public void GoDest()
        {
            if(Status == JobStatus.Copied || Status == JobStatus.Moved || Status == JobStatus.Rename_Copied || Status == JobStatus.Rename_Moved)
                System.Diagnostics.Process.Start("explorer.exe", "/select," + RealTargetPath);
        }

        string createFolder(string parent, string subFolders)
        {
            if (subFolders.IndexOf('\\') == -1)
            {
                DirectoryInfo di;
                di = Directory.CreateDirectory(parent + subFolders);
                return di.FullName;
                //  return parent+subFolders;
            }
            else
            {
                string newParent = parent + subFolders.Substring(0, subFolders.IndexOf('\\')) + "\\";
                Directory.CreateDirectory(newParent);
                return createFolder(newParent, subFolders.Substring(subFolders.IndexOf('\\') + 1));
            }
        }
        private void log(string msg, bool newLine = true)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff "); //"yyyymmdd HH:mm:ss.fff "
            if (newLine)
                StatusLog += "\r\n" + timestamp + msg;
            else
                StatusLog += timestamp + msg;
        }

    }

    public enum JobStatus
    {
        NotProcessed,
        InProgress,
        Error,
        Copied,
        Moved,
        Skipped,
        Rename_Copied,
        Rename_Moved,
    }
}
