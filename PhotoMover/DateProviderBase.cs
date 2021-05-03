using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoMover
{
    public abstract class DateProviderBase
    {
        int Priority;
        List<string> SupportedExts;
        public abstract DateTime GetDate(string filePath);

        public abstract void Register();
     
    }

}
