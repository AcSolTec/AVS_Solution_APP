using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbConctactDetail
    {
        public TbConctactDetail()
        {
            TbSponsors = new HashSet<TbSponsor>();
        }

        public int IdConctact { get; set; }
        public int? IdForm { get; set; }
        public int? IdCatCountry { get; set; }
        public string TelHome { get; set; }
        public string TelWork { get; set; }
        public string Email { get; set; }
        public bool? BitSponsor { get; set; }

        public virtual TbCatCountry IdCatCountryNavigation { get; set; }
        public virtual TbFormulary IdFormNavigation { get; set; }
        public virtual ICollection<TbSponsor> TbSponsors { get; set; }
    }
}
