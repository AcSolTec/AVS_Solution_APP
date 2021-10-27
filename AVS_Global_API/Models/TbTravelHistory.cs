using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbTravelHistory
    {
        public int IdTravel { get; set; }
        public int? IdForm { get; set; }
        public bool? BitVisPakistan { get; set; }
        public bool? BitVisCountries { get; set; }
        public bool? BitVisRefused { get; set; }
        public bool? BitRefusedPakistan { get; set; }
        public string DescRefused { get; set; }
        public string DateTravel { get; set; }
        public string Address { get; set; }
        public string Purpose { get; set; }
        public string Duration { get; set; }
        public bool? BitRemoveCountry { get; set; }
        public bool? BitConviction { get; set; }

        public virtual TbFormulary IdFormNavigation { get; set; }
    }
}
