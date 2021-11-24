using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class cuTripShipp
    {
        public int idForm { get; set; }
        public string dateEntryCuba { get; set; }
        public string dateDeparture { get; set; }
        public int? numsAdults { get; set; }
        public int? numsChildrens { get; set; }
        public byte[] PassportAdult { get; set; }
        public byte[] PassportChildren { get; set; }
        public bool? bitShippDifferent { get; set; }
        public bool? bitPpchf5 { get; set; }
        public bool? bitRschf750 { get; set; }
        public bool? bitEschf22 { get; set; }
        public bool? bitCourierNatInt { get; set; }
    }
}
