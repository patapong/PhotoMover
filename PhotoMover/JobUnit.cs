using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;

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

        private string srcFileName;
        private string srcFolderName;
        private string targetFileName;
        private string extension;
        private bool isTargetPathNameCalculated;
        private Config cfg;
        public JobUnit(string path)
        {
            cfg = Config.GetConfig();
            SourcePath = path;
            srcFileName = Path.GetFileName(path);
            srcFolderName = Path.GetDirectoryName(path);
            extension = Path.GetExtension(SourcePath);
            Status = JobStatus.NotProcessed;
            DateProvider = cfg.GetExtractorsForExt(extension).Find(p => p.IsEnabled && p.Instance != null).Instance;
            log("Job created.", false);
        }
        
        public void RenamePreview()
        {
            Status = JobStatus.InProgress;
            CalculatePath();
        }
        public void Process()
        {
            if(!isTargetPathNameCalculated)
                CalculatePath();

            if (Status == JobStatus.Error)
                return;

            Status = JobStatus.InProgress;
            
            RealTargetPath = CalculatedTargetPath;
            string targetDirName = Path.GetDirectoryName(CalculatedTargetPath);
            
            createFolder(cfg.TargetBasePath, targetDirName.Substring(cfg.TargetBasePath.Length));
            
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
                        if (!File.Exists(targetDirName + @"\" + targetFileName.Replace(extension, " (" + num.ToString() + ")" + extension)))
                        {
                            RealTargetPath = targetDirName + @"\" + targetFileName.Replace(extension, " (" + num.ToString() + ")" + extension);
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
                        File.Delete(targetDirName + @"\" + targetFileName);
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

        public bool Undo()
        {
            bool isStatusChanged = false;
            switch (Status)
            {
                case JobStatus.Copied:
                case JobStatus.Rename_Copied:
                    //delete target
                    try
                    {
                        File.Delete(RealTargetPath);
                        log("Undo copy done, target file deleted.");
                        Status = JobStatus.Action_Undo;
                    }
                    catch (Exception ex)
                    {
                        log("Undo copy failed:" + ex.Message);
                        Status = JobStatus.Error;
                    }
                    isStatusChanged = true;
                    break;
                case JobStatus.Moved:
                case JobStatus.Rename_Moved:
                    //copy back use src name
                    try
                    {
                        File.Move(RealTargetPath, SourcePath);
                        log("Undo move done, file restored to original location.");
                        Status = JobStatus.Action_Undo;
                    }
                    catch (Exception ex)
                    {
                        log("Undo move failed:" + ex.Message);
                        Status = JobStatus.Error;
                    }
                    isStatusChanged = true;
                    break;
                //case JobStatus.Skipped:
                //case JobStatus.NotProcessed:
                //case JobStatus.InProgress:
                //case JobStatus.Error:
                default:
                    log("Current job status not able to undo.");
                    break;
            }
            return isStatusChanged;
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
        
        private void CalculatePath()
        {
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
            catch (Exception ex)
            {
                log("!Failed to parse date from source file, will use file last write time. Exception msg: " + ex.Message);
                dt = DefaultInfoReader.Instance.GetDate(SourcePath, out string info);
            }

            string[] strArrayDate = new string[] { dt.Year.ToString(), dt.Month.ToString().PadLeft(2, '0'), dt.Day.ToString().PadLeft(2, '0'),
                dt.Hour.ToString().PadLeft(2,'0'), dt.Minute.ToString().PadLeft(2, '0'), dt.Second.ToString().PadLeft(2,'0') };
            string folder4CurFile = cfg.FolderStructure;

            folder4CurFile = FitDateTimeInString(folder4CurFile, strArrayDate);

            if (cfg.RenameFiles && NameMatch(srcFileName)) 
            {
                //ww - minutes
                targetFileName = FitDateTimeInString(cfg.RenameFileTemplate, strArrayDate) + extension;
            }
            else
            {
                targetFileName = srcFileName;
            }

            CalculatedTargetPath = Path.Combine(cfg.TargetBasePath, folder4CurFile, targetFileName);
            isTargetPathNameCalculated = true;
            Status = JobStatus.NameGenerated;
            log("Calculate for target file name finished.");
        }

        private bool NameMatch(string name)
        {
            name = name.ToLower();
            var filters = cfg.RenameFileFilter.ToLower().Split('|');
            return filters.Any(f => {
                var pattern = new WildcardPattern(f);
                return pattern.IsMatch(name);
            });
        }

        private string FitDateTimeInString(string input, string[] strArrayDate)
        {
            return input.Replace("yyyy", strArrayDate[0]).Replace("mm", strArrayDate[1]).Replace("dd", strArrayDate[2]).Replace("yy", strArrayDate[0].Substring(2))
                    .Replace("hh", strArrayDate[3]).Replace("ww", strArrayDate[4]).Replace("ss", strArrayDate[5]);
        }

        private void log(string msg, bool newLine = true)
        {
            string timestamp = DateTime.Now.ToString("HH:mm:ss.fff "); //"yyyyMMdd HH:mm:ss.fff "
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
        NameGenerated,
        Error,
        Copied,
        Moved,
        Skipped,
        Rename_Copied,
        Rename_Moved,
        Action_Undo,
    }
}
