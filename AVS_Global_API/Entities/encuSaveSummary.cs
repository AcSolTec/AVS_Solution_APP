using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class encuSaveSummary
    {
        public int? idForm { get; set; }
        public string comments { get; set; }
        public bool? bitReadSucc { get; set; }
        public bool? bitReadGtc { get; set; }
    }
}
