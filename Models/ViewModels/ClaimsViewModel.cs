namespace BCPLAlumniPortal.Models.ViewModels
{
    public class MedicalClaimViewModel
    {
        public Guid? id { set; get; }
        public string? employeeNumber { set; get; }
        public string? userName { set; get; }
        public DateTime? claimDate { set; get; }
        public float? totalAmountClaimed { set; get; }
        public float? totalAmountApproved { set; get; }
        public IList<MedicalClaimChargeViewModel> charges { set; get; }
    }
    public class MedicalClaimChargeViewModel
    {
        public Guid? id { set; get; }
        public string? patientName { set; get; }
        public string? patientRelationship { set; get; }
        public string? gender { set; get; }
        public string? chargeType { set; get; }
        public DateOnly startDate { set; get; }
        public DateOnly endDate { set; get; }
        public string? particulars { set; get; }
        public string? treatmentType { set; get; }
        public string? serviceProviderName { set; get; }
        public string? serviceRefNo { set; get; }
        public string? placeOfTreatment { set; get; }
        public string? isRecommended { set; get; }
        public bool isEmpanelled { set; get; }
        public float? amountClaimed { set; get; }
        public string? amountApproved { set; get; }
        public IList<IFormFile>? UploadFile { set; get; }
    }
}
