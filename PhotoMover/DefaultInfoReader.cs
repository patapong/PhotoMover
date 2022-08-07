using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoMover
{
    class DefaultInfoReader : IDateExtractor
    {
        public static readonly string EXT = ".*";
        public string Name { get; } = "DefaultBasic";
        private static DefaultInfoReader _instance = new DefaultInfoReader();
        
        public static IDateExtractor Instance
        {
            get { return _instance; }          
        }

        public DateTime GetDate(string filePath, out string info)
        {
            info = "Date aquired from the file's LastWriteTime.";
            FileInfo fileInfo = new FileInfo(filePath);
            return fileInfo.LastWriteTime;
        }

        public void Register()
        {
            Config.GetConfig().AddExtractorForExt(EXT, _instance);
            foreach (var item in Config.GetConfig().Extractors.Values.SelectMany(v => v))
            { //if there are extensions configured to use DefaultBasic, we just fill in the instance for the proxy here.
                if (item.Name.Equals(Name))
                {
                    item.Instance = _instance;
                }
            }
        }
    }
}
