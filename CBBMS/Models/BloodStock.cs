namespace CBBMS.Models
{
    public class BloodStock
    {
        public int Id { get; set; }
        public string BloodType { get; set; }  

        public DateTime DonationDate { get; set; }

        public DateTime ExpiryDate { get; set; } 

        public bool IsAvailable { get; set; } 

        public int BloodBankId { get; set; } 

        public BloodBank BloodBank { get; set; }
    }
}
