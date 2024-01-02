namespace BCPLAlumniPortal.Models
{
    public class MedicalClaimCharges
    {
        public Guid id { set; get; }
        public string? patientName { set; get; }
        public string? patientRelationship { set; get; }
        public string? gender { set; get; }
        public string? chargeType { set; get; }
        public DateOnly? startDate { set; get; }
        public DateOnly? endDate { set; get; }
        public string? particulars { set; get; }
        public string? treatmentType { set; get; }
        public string? serviceProviderName { set; get; }
        public string? serviceRefNo { set; get;}
        public string? placeOfTreatment { set; get; }
        public string? isRecommended { set; get; }
        public bool isEmpanelled { set; get; }
        public float? amountClaimed { set; get; }
        public float? amountApproved { set; get; }
        public ICollection<UserMedicalClaimAttachment> attachments { set; get; }
    }
}
