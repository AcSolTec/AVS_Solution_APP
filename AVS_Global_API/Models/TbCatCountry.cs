using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbCatCountry
    {
        public TbCatCountry()
        {
            TbConctactDetails = new HashSet<TbConctactDetail>();
            TbConvictionsTravels = new HashSet<TbConvictionsTravel>();
            TbDeportedTravels = new HashSet<TbDeportedTravel>();
            TbPersonalData = new HashSet<TbPersonalDatum>();
        }

        public int IdCatCountry { get; set; }
        public string Country { get; set; }
        public bool? BitActive { get; set; }

        public virtual ICollection<TbConctactDetail> TbConctactDetails { get; set; }
        public virtual ICollection<TbConvictionsTravel> TbConvictionsTravels { get; set; }
        public virtual ICollection<TbDeportedTravel> TbDeportedTravels { get; set; }
        public virtual ICollection<TbPersonalDatum> TbPersonalData { get; set; }
    }
}
