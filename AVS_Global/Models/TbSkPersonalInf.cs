using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbSkPersonalInf
    {
        public int IdPerson { get; set; }
        public int? IdForm { get; set; }
        public int? IdCountry { get; set; }
        public bool? BitSex { get; set; }
        public string NamePassport { get; set; }
        public bool? BitNameUknown { get; set; }
        public string Surname { get; set; }
        public bool? BitSurNamUknown { get; set; }
        public string DateBirth { get; set; }
        public string PassportNum { get; set; }
        public string DateExpiredPassport { get; set; }
    }
}
