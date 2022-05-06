namespace AVS_Global.Models
{
    public class Root
    {
        public RequestHeader RequestHeader { get; set; }
        public string TerminalId { get; set; }
        public Payment Payment { get; set; }
        //public Payer Payer { get; set; }
        public Notification Notification { get; set; }
        public ReturnUrls ReturnUrls { get; set; }

    }
}
