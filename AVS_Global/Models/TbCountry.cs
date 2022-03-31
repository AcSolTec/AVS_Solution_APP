using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbCountry
    {
        public TbCountry()
        {
            TbCustomersAvs = new HashSet<TbCustomersAv>();
            TbFormularies = new HashSet<TbFormulary>();
        }

        public int IdCountry { get; set; }
        public string Name { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public bool? BitActive { get; set; }

        public virtual ICollection<TbCustomersAv> TbCustomersAvs { get; set; }
        public virtual ICollection<TbFormulary> TbFormularies { get; set; }
    }
}
