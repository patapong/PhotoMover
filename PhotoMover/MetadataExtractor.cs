using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    internal class MetadataExtractor : IDateExtractor
    {
        public string Name { get; } = "MetadataExtractor";
        private static MetadataExtractor _instance = new MetadataExtractor();
        private static readonly int DT_ORIG = 36867;
        private static readonly int DT_ORIG_TZ = 36881;
        private static readonly int DT_IFD0 = 306;
        private static readonly int DT_AVI_ORIG = 320;
        public DateTime GetDate(string filePath, out string info)
        {
            try
            {
                DateTime result;
                var meta = global::MetadataExtractor.ImageMetadataReader.ReadMetadata(filePath);
                string ext = Path.GetExtension(filePath).ToLower();
                if (ext == ".mp4" || ext == ".mov")
                {
                    var tagCreated = meta.SelectMany(m => m.Tags).Where(t => t.Name.Equals("Created")).First();
                    //		Description	"Thu May 26 10:08:10 2022"	string
                    if(tagCreated != null)
                    {
                        result = DateTimeOffset.ParseExact(tagCreated.Description, "ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture).DateTime;
                        info = "Date aquired from the movie file's meta tags 'Created'";
                        return result;
                    }
                    throw new Exception("cant find date in the mp4!");
                }

                var tags = meta.SelectMany(m => m.Tags).GroupBy(m => m.Type).Select(g => g.First()).ToDictionary(t => t.Type, t => t);
                if (tags.ContainsKey(DT_ORIG))
                {
                    if (tags.ContainsKey(DT_ORIG_TZ))
                    {
                        result = DateTimeOffset.ParseExact(tags[DT_ORIG].Description + tags[DT_ORIG_TZ].Description, "yyyy:MM:dd HH:mm:sszzz", CultureInfo.InvariantCulture).DateTime;
                        info = "Date aquired from the exif DT_ORIG and with timezone information ";
                    }
                        
                    else
                    {
                        result = DateTimeOffset.ParseExact(tags[DT_ORIG].Description, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture).DateTime;
                        info = "Date aquired from the exif DT_ORIG and without timezone information ";
                    }
                }
                else if(tags.ContainsKey(DT_IFD0))
                {
                    result = DateTimeOffset.ParseExact(tags[DT_IFD0].Description, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture).DateTime;
                    info = "Date aquired from the exif DT_IFD0 without timezone information ";
                }
                else if (tags.ContainsKey(DT_AVI_ORIG))
                { //Tue Jul 15 19:04:47 2003
                    result = DateTimeOffset.ParseExact(tags[DT_AVI_ORIG].Description, "ddd MMM dd HH:mm:ss yyyy", CultureInfo.InvariantCulture).DateTime;
                    info = "Date aquired from the exif DT_AVI_ORIG without timezone information ";
                }
                else
                {
                    throw new Exception("Date information not found from known locations.");
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Register()
        {
            var cfg = Config.GetConfig();
            cfg.AddExtractorForExt(".jpg", _instance);
            cfg.AddExtractorForExt(".mp4", _instance);
            cfg.AddExtractorForExt(".avi", _instance);
            cfg.AddExtractorForExt(".mov", _instance);
            cfg.AddExtractorForExt(".heic", _instance);
            cfg.AddExtractorForExt(".cr2", _instance);
            cfg.AddExtractorForExt(".cr3", _instance);
            cfg.AddExtractorForExt(".dng", _instance);
            cfg.AddExtractorForExt(".nef", _instance);
            cfg.AddExtractorForExt(".arw", _instance);
            cfg.AddExtractorForExt(".raf", _instance);

            //allow new extension add from config file, if you know MetadataExtractor supports it
            foreach (var item in Config.GetConfig().Extractors.Values.SelectMany(v => v))
            {
                if (item.Name.Equals(Name) && item.Instance == null)
                {
                    item.Instance = _instance;
                }
            }
        }
    }
}
