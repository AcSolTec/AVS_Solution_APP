using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global_API.Models
{
    public partial class TbFamilyDetail
    {
        public TbFamilyDetail()
        {
            TbAcompanyingFamilies = new HashSet<TbAcompanyingFamily>();
            TbBankFamilies = new HashSet<TbBankFamily>();
            TbChildrensFamiliys = new HashSet<TbChildrensFamiliy>();
        }

        public int IdFam { get; set; }
        public int? IdForm { get; set; }
        public string Nmother { get; set; }
        public string Npather { get; set; }
        public int? IdNatMother { get; set; }
        public int? IdNatFather { get; set; }
        public string SpouseName { get; set; }
        public int? IdNatSpouse { get; set; }
        public string DateBirth { get; set; }
        public string PlaceBirth { get; set; }
        public string Profesion { get; set; }
        public bool? BitChildrens { get; set; }
        public bool? BitAcompany { get; set; }
        public bool? BitAccountBank { get; set; }
        public string NameEmployerSpouse { get; set; }
        public string AddressEmployerSpouse { get; set; }
        public string TelEmployerSpouse { get; set; }

        public virtual TbFormulary IdFormNavigation { get; set; }
        public virtual ICollection<TbAcompanyingFamily> TbAcompanyingFamilies { get; set; }
        public virtual ICollection<TbBankFamily> TbBankFamilies { get; set; }
        public virtual ICollection<TbChildrensFamiliy> TbChildrensFamiliys { get; set; }
    }
}
