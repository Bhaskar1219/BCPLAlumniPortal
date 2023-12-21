namespace BCPLAlumniPortal.Models.ViewModels
{
    public class MedicalClaimViewModel
    {
        public string? id { set; get; }
        public DateTime claimDate { set; get; }
        public string patientName { set; get; }
        public string patientRelationship { set; get; }
        public string gender { set; get; }
        public bool isEmpanelled { set; get; }
        public int claimAmount { set; get; }
    }
}
