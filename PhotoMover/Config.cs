using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    public class Config
    {
        private static Config instance;
        public static Config InitConfig(string configPath)
        {
            if (File.Exists(configPath))
            {
                TextReader reader = new StreamReader(configPath);
                instance = JsonConvert.DeserializeObject<Config>(reader.ReadToEnd());
                reader.Close();
                if(instance.Extractors == null)
                {
                    instance.Extractors = new Dictionary<string, List<DateExtractorProxy>>();
                }
            }
            else
            {
                instance = new Config();
                instance.Recursive = true;
                instance.DeleteEmptySrcFolder = true;
                instance.TargetRule = RuleForTargetExists.skip;
                instance.DeleteSourceFile = false;
                instance.ShowList = true;
                instance.Extractors = new Dictionary<string, List<DateExtractorProxy>>();
            }
            return instance;
        }
        public static Config GetConfig()
        {
            return instance;
        }
        public void SaveConfig(string configPath)
        {
            TextWriter tw = new StreamWriter(configPath);
            JsonSerializer jsz = JsonSerializer.Create(new JsonSerializerSettings() { Formatting = Formatting.Indented });
            jsz.Serialize(tw, instance);
            tw.Close();
        }
        
        public string SourceBasePath { get; set; }
        public string TargetBasePath { get; set; }
        public string FolderStructure { get; set; }

        public bool DeleteEmptySrcFolder { get; set; }

        public RuleForTargetExists TargetRule { get; set; }
        public bool Recursive { get; set; }
        
        //if true, means Move. if false means copy
        public bool DeleteSourceFile { get; set; }
        public bool ShowList { get; set; }
        
        public List<string> HistorySourcePathes { get; set; }
        public List<string> HistoryTargetPathes { get; set; }
        public List<string> HistoryFolderStructures { get; set; }
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
