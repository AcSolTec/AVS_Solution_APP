using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbAcompanyingFamily
    {
        public int IdAcomp { get; set; }
        public int? IdFam { get; set; }
        public string FullName { get; set; }
        public string DateOfBirth { get; set; }
        public string PassportNumber { get; set; }
        public string Address { get; set; }

        public virtual TbFamilyDetail IdFamNavigation { get; set; }
    }
}
