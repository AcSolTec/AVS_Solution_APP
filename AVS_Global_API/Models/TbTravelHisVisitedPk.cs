using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbTravelHisVisitedPk
    {
        public int IdTravelDetail { get; set; }
        public int? IdForm { get; set; }
        public string DateTravel { get; set; }
        public string Address { get; set; }
        public string Purpose { get; set; }
        public string Duration { get; set; }
        public bool? BitVisPakistan { get; set; }
        public bool? BitVisCountries { get; set; }
    }
}
