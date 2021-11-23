using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global_API.Entities
{
    public class enpkSaveFamilyBank
    {
        public int idForm { get; set; }
        public bool bitBank { get; set; }
        public string nameBank { get; set; }
        public string branch { get; set; }
        public string acNumber { get; set; }
        public string address { get; set; }
        public string verifierDetails { get; set; }
    }
}
