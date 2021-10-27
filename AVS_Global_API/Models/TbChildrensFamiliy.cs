using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbChildrensFamiliy
    {
        public int IdChild { get; set; }
        public int? IdFam { get; set; }
        public string NameChild { get; set; }
        public string DateOfBith { get; set; }

        public virtual TbFamilyDetail IdFamNavigation { get; set; }
    }
}
