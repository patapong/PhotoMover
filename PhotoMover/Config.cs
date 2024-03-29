﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace PhotoMover
{
    [DataContract]
    public class Config
    {
        private static Config instance;
        public static readonly DataContractJsonSerializerSettings Settings = new DataContractJsonSerializerSettings { UseSimpleDictionaryFormat = true };
        public static Config InitConfig(string configPath)
        {
            if (File.Exists(configPath))
            {
                var ser = new DataContractJsonSerializer(typeof(Config), Settings);
                Stream stream = new FileStream(configPath, FileMode.Open, FileAccess.Read);
                instance = (Config)ser.ReadObject(stream);
                stream.Close();
                //TextReader reader = new StreamReader(configPath);
                //instance = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
                //reader.Close();

                if (instance.Extractors == null)
                {
                    instance.Extractors = new Dictionary<string, List<DateExtractorProxy>>();
                }
            }
            else
            {
                instance = new Config();
                instance.Recursive = true;
                instance.DeleteEmptySrcFolder = false;
                instance.TargetRule = RuleForTargetExists.skip;
                instance.DeleteSourceFile = false;
                instance.ShowList = true;
                instance.Extractors = new Dictionary<string, List<DateExtractorProxy>>();
                instance.SourceFileFilter = "*.*";
                instance.RenameFileFilter = "A*.jpg|M*.mov";
                instance.RenameFileTemplate = "yyyymmdd-hhwwss";
            }
            return instance;
        }
        public static Config GetConfig()
        {
            return instance;
        }
        public void SaveConfig(string configPath)
        {
            using (var stream = File.Open(configPath, FileMode.Create))
            {
                using (var writer = JsonReaderWriterFactory.CreateJsonWriter(
                        stream, System.Text.Encoding.UTF8, true, true, "  "))
                {
                    var serializer = new DataContractJsonSerializer(typeof(Config), Settings);
                    serializer.WriteObject(writer, instance);
                    writer.Close();
                }
            }
            //TextWriter tw = new StreamWriter(configPath);
            //JsonSerializer jsz = JsonSerializer.Create(new JsonSerializerSettings() { Formatting = Formatting.Indented });
            //jsz.Serialize(tw, instance);
            //tw.Close();
        }

        public bool isPreviewOnly { get; set; }

        [DataMember(Order = 10)]
        public string SourceBasePath { get; set; }

        [DataMember(Order = 11)]
        public string SourceFileFilter { get; set; } = "*.jpg|*.cr3";

        [DataMember(Order = 12)]
        public string TargetBasePath { get; set; }
        [DataMember(Order = 20)]
        public string FolderStructure { get; set; }

        [DataMember(Order = 21)]
        public bool RenameFiles { get; set; } = false;
        [DataMember(Order = 22)]
        public string RenameFileFilter { get; set; } = "C*.jpg|*.avi";
        [DataMember(Order = 23)]
        public string RenameFileTemplate { get; set; }

        [DataMember(Order = 30)]
        public bool DeleteEmptySrcFolder { get; set; }
        [DataMember(Order = 31)]
        public RuleForTargetExists TargetRule { get; set; }
        [DataMember(Order = 32)]
        public bool Recursive { get; set; }

        //if true, means Move. if false means copy
        [DataMember(Order = 33)]
        public bool DeleteSourceFile { get; set; }
        [DataMember(Order = 40)]
        public bool ShowList { get; set; }
        [DataMember(Order = 50)]
        public List<string> HistorySourcePathes { get; set; }
        [DataMember(Order = 51)]
        public List<string> HistoryTargetPathes { get; set; }
        [DataMember(Order = 52)]
        public List<string> HistoryFolderStructures { get; set; }

        [DataMember(Order = 99)]
        public Dictionary<string,List<DateExtractorProxy>> Extractors { get; set; }
        public List<DateExtractorProxy> GetExtractorsForExt(string ext)
        {
            ext = ext.ToLower();
            List<DateExtractorProxy> extractorsForExt;
            Extractors.TryGetValue(ext.ToLower(), out extractorsForExt);
            if(extractorsForExt == null || extractorsForExt.All(x => x.Instance == null || !x.IsEnabled))
            {
                extractorsForExt = new List<DateExtractorProxy>();
                var proxy = new DateExtractorProxy() { Name = DefaultInfoReader.Instance.Name, Instance = DefaultInfoReader.Instance};
                extractorsForExt.Add(proxy);
                Extractors[ext] = extractorsForExt;
            }
            return extractorsForExt;
        }

        public bool AddExtractorForExt(string ext, IDateExtractor extractor)
        {
            ext = ext.ToLower();
            List<DateExtractorProxy> extractorProxysForExt;
            if (Extractors.TryGetValue(ext, out extractorProxysForExt))
            {
                var existingProxy = extractorProxysForExt.Where(x => x.Name.Equals(extractor.Name)); //same name already in config
                if(existingProxy.Count() > 0)
                {
                    existingProxy.First().Instance = extractor;
                }
                else
                {
                    var proxy = new DateExtractorProxy() { Name = extractor.Name, Instance = extractor };
                    extractorProxysForExt.Add(proxy);
                }                
            }
            else
            {
                extractorProxysForExt = new List<DateExtractorProxy>();
                var proxy = new DateExtractorProxy() { Name = extractor.Name, Instance = extractor };
                extractorProxysForExt.Add(proxy); //default is enabled and loaded
                Extractors[ext] = extractorProxysForExt;
            }
            return true;
        }
    }
    public enum RuleForTargetExists
    {
        skip,
        overwrite,
        rename
    }
}
