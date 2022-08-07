using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoMover
{
    public class DateExtractorProxy
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; } = true;
        [JsonIgnore]
        public IDateExtractor Instance { get; set; }

    }
}
