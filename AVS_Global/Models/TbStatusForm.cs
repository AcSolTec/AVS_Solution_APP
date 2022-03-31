using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbStatusForm
    {
        public TbStatusForm()
        {
            TbFormularies = new HashSet<TbFormulary>();
        }

        public int IdStatus { get; set; }
        public string Description { get; set; }
        public bool? BitActive { get; set; }

        public virtual ICollection<TbFormulary> TbFormularies { get; set; }
    }
}
