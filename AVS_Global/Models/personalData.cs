using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class personalData
    {
        public int IdPd { get; set; }
        public int? IdForm { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DateBirth { get; set; }
        public string CityBirth { get; set; }
        public int? IdCatCountry { get; set; }
        public bool? TypeSex { get; set; }
        public string BloodGroup { get; set; }
        public bool? MaritalStatus { get; set; }
        public string IdMark { get; set; }
        public string DetailOfProfesion { get; set; }
        public string Religion { get; set; }
        public DateTime? DateOfChange { get; set; }
        public string Pvpakistan { get; set; }
        public int? IdPurpose { get; set; }
        public int? IdPortsIn { get; set; }
        public int? IdPortsOut { get; set; }
        public int? IdVisaAp { get; set; }
        public string DurationStay { get; set; }
        public int? IdVisasTime { get; set; }
        public int? IdTypeVisa { get; set; }
        public string NativeLanguage { get; set; }
        public string NationPresent { get; set; }
        public string NationPrevious { get; set; }
        public string NationDual { get; set; }

    }
}
