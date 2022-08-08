using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    public class XmpDateExtractor : IDateExtractor
    {
        public string Name { get; } = "Xmp DateExtractor";
        private static XmpDateExtractor _instance = new XmpDateExtractor();
        public DateTime GetDate(string filePath, out string info)
        {
            DateTime date = DateTime.Now;
            bool found = false;
            StreamReader Textfile = new StreamReader(filePath);
            try
            {
                string line;
                while ((line = Textfile.ReadLine()) != null)
                {
                    if (line.Contains("exif:DateTimeOriginal"))
                    {
                        string timeStr = line.Split('=')[1].Trim('"');
                        if(timeStr.Length > 19)
                            date = DateTime.ParseExact(timeStr, "yyyy-MM-ddTHH:mm:ss.ffzzz", CultureInfo.InvariantCulture);
                        else
                            date = DateTime.ParseExact(timeStr, "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                        found = true;
                        break;
                    }
                }
                if (!found)
                    throw new Exception("no DateTimeOriginal found in the xmp file.");
                else
                {
                    info = line;
                    return date;
                }
                    
            }
            catch (Exception)
            {
                throw new Exception("Failed to get date from xmp content");
            }
            finally
            {
                Textfile.Close();
            }
        }

        public void Register()
        {
            Config.GetConfig().AddExtractorForExt(".xmp", _instance);
        }
    }
}
