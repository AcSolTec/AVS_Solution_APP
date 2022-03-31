using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbCustomersAv
    {
        public TbCustomersAv()
        {
            TbFormularies = new HashSet<TbFormulary>();
        }

        public int IdCustomer { get; set; }
        public int? IdCountry { get; set; }
        public string RegisteredMail { get; set; }
        public string Pass { get; set; }
        public string Seed { get; set; }
        public DateTime? DateOfEntry { get; set; }
        public DateTime? DateValidity { get; set; }

        public virtual TbCountry IdCountryNavigation { get; set; }
        public virtual ICollection<TbFormulary> TbFormularies { get; set; }
    }
}
