namespace CBBMS.Models
{
    public class BloodRequest
    {
        public int Id { get; set; }
        public string BloodType { get; set; }

        public string PatientStatus { get; set; }

        public int Quantity { get; set; }

        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string HospitalId { get; set; }
        public Hospital Hospital { get; set; }

    }
}
