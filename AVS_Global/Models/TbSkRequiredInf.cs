using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
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
        public string SponsorName { get; set; }
        public string AddressNumber { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public int? IdPurpose { get; set; }
    }
}
