using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class enpkSavePassportData
    {
        public int IdForm { get; set; }
        public int IdTypePass { get; set; }
        public bool TravelDocs { get; set; }
        public string PassportNumber { get; set; }
        public string PlaceOfIssue { get; set; }
        public string DateOfIssue { get; set; }
        public string DateOfExpiry { get; set; }
        public string IssuingAuth { get; set; }
    }
}
