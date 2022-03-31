using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbConvictionsTravel
    {
        public int IdConviction { get; set; }
        public string DateConvict { get; set; }
        public int? IdCatCountry { get; set; }
        public string Offence { get; set; }
        public string Sentence { get; set; }
        public int? IdForm { get; set; }

        public virtual TbCatCountry IdCatCountryNavigation { get; set; }
    }
}
