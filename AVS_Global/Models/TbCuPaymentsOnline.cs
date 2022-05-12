using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbCuPaymentsOnline
    {
        public int IdPayment { get; set; }
        public int? IdForm { get; set; }
        public string RequestId { get; set; }
        public string SpecVersion { get; set; }
        public string Token { get; set; }
        public string Expiration { get; set; }
        public string RedUrl { get; set; }
        public DateTime? DateTransc { get; set; }
    }
}
