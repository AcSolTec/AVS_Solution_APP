using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbTravelHistoryDatum
    {
        public int IdTravel { get; set; }
        public int? IdForm { get; set; }
        public bool? BitRefused { get; set; }
        public bool? BitRefusedPakistan { get; set; }
        public bool? BitRemoveCountry { get; set; }
        public bool? BitConviction { get; set; }
        public string DetailRefusal { get; set; }
    }
}
