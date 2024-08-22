namespace DivyangCareerApi.Models
{
    public class CandidateApplyJob
    {
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public string Resume { get; set; }
    }
}
