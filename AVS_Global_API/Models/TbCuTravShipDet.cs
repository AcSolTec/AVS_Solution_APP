using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbCuTravShipDet
    {
        public int IdTravShip { get; set; }
        public int? IdForm { get; set; }
        public string DateEntryCuba { get; set; }
        public string DateDeparture { get; set; }
        public int? NumsAdults { get; set; }
        public int? NumsChildrens { get; set; }
        public byte[] PassportAdult { get; set; }
        public byte[] PassportChildren { get; set; }
        public bool? BitShippDifferent { get; set; }
        public bool? BitPpchf5 { get; set; }
        public bool? BitRschf750 { get; set; }
        public bool? BitEschf22 { get; set; }
        public bool? BitCourierNatInt { get; set; }
    }
}
