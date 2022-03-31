using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbUser
    {
        public int IdUser { get; set; }
        public int? IdRol { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public string KeyAccess { get; set; }
        public string Seed { get; set; }
        public string Pass { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public DateTime? DateValidity { get; set; }

        public virtual TbRole IdRolNavigation { get; set; }
    }
}
