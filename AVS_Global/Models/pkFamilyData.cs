using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class pkFamilyData
    {
        public int IdForm { get; set; }
        public string Nmother { get; set; }
        public string Npather { get; set; }
        public int IdNatMother { get; set; }
        public int IdNatFather { get; set; }
        public string SpouseName { get; set; }
        public int? IdNatSpouse { get; set; }
        public string DateBirth { get; set; }
        public string PlaceBirth { get; set; }
        public string Profesion { get; set; }
        public bool BitChildrens { get; set; }
        public string NameEmployerSpouse { get; set; }
        public string AddressEmployerSpouse { get; set; }
        public string TelEmployerSpouse { get; set; }
    }
}
