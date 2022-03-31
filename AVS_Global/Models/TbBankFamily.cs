using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbBankFamily
    {
        public int IdBank { get; set; }
        public int? IdFam { get; set; }
        public string NameBank { get; set; }
        public string Branch { get; set; }
        public string Acnumber { get; set; }
        public string Address { get; set; }
        public string VerifierDetails { get; set; }

        public virtual TbFamilyDetail IdFamNavigation { get; set; }
    }
}
