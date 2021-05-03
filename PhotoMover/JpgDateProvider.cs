using PhotosTool.EXIF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoMover
{
    public class JpgDateProvider : DateProviderBase
    {
        public static readonly string EXT = ".jpg";

        private static string TimeFieldName = "DTOrig";
        private static int[] dateFieldIds = new int[3] { 0x9003, 0x132, 0x9004 };
        private static JpgDateProvider _instance = new JpgDateProvider();

        public override void Register()
        {
            FileProcessorFactory.addExt(EXT, _instance);
        }

        public override DateTime GetDate(string objFile)
        {
            try
            {
                FileStream stream = new FileStream(objFile, FileMode.Open, FileAccess.Read);
                PropertyItem[] parr = Image.FromStream(stream, true, false).PropertyItems;
                stream.Close();
                Encoding aSCII = Encoding.ASCII;
                var dict = parr.ToDictionary(p => p.Id);
                string dateString = null;
                foreach (int x in dateFieldIds)
                {
                    dict.TryGetValue(x, out PropertyItem pItem);
                    if (pItem != null)
                    {
                        dateString = aSCII.GetString(pItem.Value);                        
                        break; //0x9003, 0x132, 0x9004, use DTOrig as first priority, then DateTime, then the modify Date
                    }
                }
                if (dateString == null)
                { //get exif date from jpg failed
                    //_error++;
                    //UpdateStatusBar(tssError, "出错: " + _error.ToString());
                    //UpdateState(info.FullName, state: STATE.error_info);
                    //continue;
                    throw new Exception("Empty exif date!");
                }
                DateTime result = DateTime.Parse(dateString);
                return result;
            }
            catch (Exception ex)
            {
                //_error++;
                //UpdateStatusBar(tssError, "出错: " + _error.ToString());
                //UpdateState(info.FullName, state: STATE.error_info);
                //continue;
                throw ex;
            }
        }

        public int Priority()
        {
            return 1;
        }

        public void setTimeFieldName(string tfn)
        {
            TimeFieldName = tfn;
        }

        public List<string> SupportedExts()
        {
            throw new NotImplementedException();
        }

    }
}
