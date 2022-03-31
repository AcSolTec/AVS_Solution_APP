using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbPassportDetail
    {
        public int IdPassport { get; set; }
        public int? IdForm { get; set; }
        public int? IdTypePass { get; set; }
        public bool? TravelDocs { get; set; }
        public string PassportNumber { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
        public string IssuingAuth { get; set; }
        public DateTime? DateOfChange { get; set; }

        public virtual TbFormulary IdFormNavigation { get; set; }
    }
}
