namespace BCPLAlumniPortal.Models
{
    public class UserMedicalClaimAttachment
    {
        public Guid id { set; get; }
        public string FileName { get; set; }
        public string FileType { set; get; }
        public string FilePath { set; get; }
        public double FileSize { set; get; }
    }
}
