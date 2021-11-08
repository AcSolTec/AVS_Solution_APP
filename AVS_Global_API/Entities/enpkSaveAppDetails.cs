using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class enpkSaveAppDetails
    {
        public int idForm { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dateBirth { get; set; }
        public string cityBirth { get; set; }
        public int idCountry { get; set; }
        public bool bitSex { get; set; }
        public bool bitMarital { get; set; }
        public string bloodGroup { get; set; }
        public string idMark { get; set; }
        public string natLanguage { get; set; }
        public string religion { get; set; }
        public string natPresent { get; set; }
        public string natPrevious { get; set; }
        public string natDual { get; set; }
    }
}
