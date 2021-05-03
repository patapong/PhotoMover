using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoMover
{
    class FileProcessorFactory
    {
        private static Dictionary<string, DateProviderBase> processorVault = new Dictionary<string, DateProviderBase>();
        /**
         * ext should be a string contains '.'. e.g., .jpg, or c:\folder\abc.jpg
         * 
         */
        public static DateProviderBase getReader(string ext)
        {
            DateProviderBase reader;
            if (!ext.StartsWith("."))
            {
                ext = ext.Substring(ext.LastIndexOf("."));
            }
            if (!processorVault.TryGetValue(ext.ToLower(), out reader))
            {
                reader = DefaultInfoReader.Instance;
            }

            return reader;
        }

        public static bool addExt(string ext, DateProviderBase handler)
        {
            try
            {
                processorVault.Add(ext, handler);
            }
            catch (ArgumentException ex)
            {
                return false;
            }
            return true;
        }
    }
}
