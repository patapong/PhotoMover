using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    [DataContract]
    public class DateExtractorProxy
    {
        [DataMember(Order = 1)]
        public string Name { get; set; }
        [DataMember(Order = 2)]
        public bool IsEnabled { get; set; } = true;
        
        public IDateExtractor Instance { get; set; }

    }
}
