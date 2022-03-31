using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbRole
    {
        public TbRole()
        {
            TbUsers = new HashSet<TbUser>();
        }

        public int IdRol { get; set; }
        public string NameRol { get; set; }
        public bool? BitActive { get; set; }

        public virtual ICollection<TbUser> TbUsers { get; set; }
    }
}
