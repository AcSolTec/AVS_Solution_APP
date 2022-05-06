using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AVS_Global.Models
{
    public class enReqPayment
    {
        public string TerminalId { get; set; }
       // public PaymentTest Payment { get; set; }
        public Notification Notification { get; set; }
        //public Payer Payer { get; set; }
        public Order Order { get; set; }
        public RiskFactors RiskFactors { get; set; }
        public RequestHeader RequestHeader { get; set; }
        public ReturnUrls ReturnUrls { get; set; }
    }

    public class Notification
    {
        public string SuccessNotifyUrl { get; set; }
        public string FailNotifyUrl { get; set; }
    }

    public class PayerTest
    {
        public BillingAddress BillingAddress { get; set; }
    }

    public class BillingAddress
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
    }

    public class Order
    {
        public List<Items> Items { get; set; }
    }

    public class Items
    {
        public string Type { get; set; }
        public int Quantity { get; set; }
        public string Name { get; set; }
        public double UnitPrice { get; set; }
    }

    public class RiskFactors {
        public string DeliveryType { get; set; }
        public PayerProfile PayerProfile { get; set; }
    }

    public class PayerProfile
    {
        public bool HasAccount { get; set; }
        public bool HasPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public Phone Phone { get; set; }
    }

    public class Phone
    {
        public string Main { get; set; }
        public string Mobile { get; set; }
    }

}
