namespace BCPLAlumniPortal.Models
{
    public class UserMedicalClaim
    {
        public Guid id { set;get; }
        public string employeeNumber { set;get; }
        public string userName { set;get; }
        public DateTime claimDate { set;get; }
        public float? totalAmountClaimed { set; get; }
        public float? totalAmountApproved { set; get; }
        public bool isSubmitted { set; get; }
        public ICollection<MedicalClaimCharges>? charges { set; get; }
    }
}
