using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhotoMover
{
    class DefaultInfoReader : DateProviderBase
    {
        public static readonly string EXT = ".*";
        private static DefaultInfoReader _instance = new DefaultInfoReader();
     
        public static DefaultInfoReader Instance
        {
            get { return _instance; }          
        }

        public override DateTime GetDate(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            return info.LastWriteTime;
        }

        public override void Register()
        {
            FileProcessorFactory.addExt(EXT, _instance);
        }
    }
}
