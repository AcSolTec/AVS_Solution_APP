using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbSkRequiredInf
    {
        public int IdReq { get; set; }
        public int? IdForm { get; set; }
        public bool? BitOtherNat { get; set; }
        public string MobileNumber { get; set; }
        public bool? BitVisitedKorea { get; set; }
        public int? IdCountry { get; set; }
        public string PostalCode { get; set; }
        public string AddressPostal { get; set; }
        public string NumberContactKorea { get; set; }
        public int? IdJob { get; set; }
        public bool? BitInfectiuos15 { get; set; }
        public bool? BitArrested { get; set; }
    }
}
