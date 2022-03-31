using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbDeportedTravel
    {
        public int IdDeport { get; set; }
        public string DateDeport { get; set; }
        public int? IdCatCountry { get; set; }
        public string Reason { get; set; }
        public string ReferenceNum { get; set; }
        public int? IdForm { get; set; }

        public virtual TbCatCountry IdCatCountryNavigation { get; set; }
    }
}
