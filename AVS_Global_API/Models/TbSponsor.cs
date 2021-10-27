using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbSponsor
    {
        public int IdSponsor { get; set; }
        public int? IdConctact { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string TelPhone { get; set; }
        public string TelHome { get; set; }
        public string TelWork { get; set; }

        public virtual TbConctactDetail IdConctactNavigation { get; set; }
    }
}
