using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class pkPassportData
    {
        public int idForm { get; set; }
        public int idTypePass { get; set; }
        public bool travelDocs { get; set; }
        public string passportNumber { get; set; }
        public string placeOfIssue { get; set; }
        public string dateOfIssue { get; set; }
        public string dateOfExpiry { get; set; }
        public string issuingAuth { get; set; }
    }
}
