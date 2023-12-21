namespace BCPLAlumniPortal.Models
{
    public class UserMedicalClaim
    {
        public Guid id { set;get; }
        public string employeeNumber { set;get; }
        public string userName { set;get; }
        public DateTime claimDate { set;get; }
        public string patientName { set;get; }
        public string patientRelationship { set; get; }
        public string gender { set; get; }
        public bool isEmpanelled { set;get; }
        public int claimAmount { set;get; }
    }
}
