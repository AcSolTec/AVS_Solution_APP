using System;
using System.Collections.Generic;

#nullable disable

namespace AVS_Global.Models
{
    public partial class TbFormulary
    {
        public TbFormulary()
        {
            TbConctactDetails = new HashSet<TbConctactDetail>();
            TbFamilyDetails = new HashSet<TbFamilyDetail>();
            TbPassportDetails = new HashSet<TbPassportDetail>();
            TbPastJobs = new HashSet<TbPastJob>();
            TbPersonalData = new HashSet<TbPersonalDatum>();
            TbTravelHistories = new HashSet<TbTravelHistory>();
        }

        public int IdForm { get; set; }
        public int? IdCountry { get; set; }
        public int? IdCustomer { get; set; }
        public int? IdStatus { get; set; }
        public DateTime? DateOfEntry { get; set; }

        public virtual TbCountry IdCountryNavigation { get; set; }
        public virtual TbCustomersAv IdCustomerNavigation { get; set; }
        public virtual TbStatusForm IdStatusNavigation { get; set; }
        public virtual ICollection<TbConctactDetail> TbConctactDetails { get; set; }
        public virtual ICollection<TbFamilyDetail> TbFamilyDetails { get; set; }
        public virtual ICollection<TbPassportDetail> TbPassportDetails { get; set; }
        public virtual ICollection<TbPastJob> TbPastJobs { get; set; }
        public virtual ICollection<TbPersonalDatum> TbPersonalData { get; set; }
        public virtual ICollection<TbTravelHistory> TbTravelHistories { get; set; }
    }
}
