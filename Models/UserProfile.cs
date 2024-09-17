using System.Web.Mvc;

namespace DivyangCareerApi.Models
{
    public class UserProfile
    {
        public int CandidateId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CountryCode { get; set; }
        public string ProfileImage { get; set; }
        public string GuardianName { get; set; }
        public string DBO { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public string Gender { get; set; }
        public string PrimaryLanguage { get; set; }
        public string EmploymentStatus { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string SubDistrict { get; set; }
        public string Cities { get; set; }
        public string AddressType { get; set; }
        public string AddressSubType { get; set; }
        public string TerritoryTypes { get; set; }
        public string PinCode { get; set; }
        public string MaritalStatus { get; set; }
        public string Religions { get; set; }
        public string Castes { get; set; }
        public string UIDType { get; set; }
        public string UIDNumber { get; set; }
        public string CVName { get; set; }
        public string HighestEducationAttained { get; set; }
        public string EducationQualification { get; set; } = string.Empty;
        public string Institute { get; set; }
        public string Month { get; set; }
        public string Years { get; set; }
        public string GradePercentagePercentileType { get; set; }
        public string GradePercentagePercentileValue { get; set; }
        public string CourseNature { get; set; }
        public string MediumOfEducation { get; set; }
        public string CertificateName { get; set; }
        public string CertificateYear { get; set; }
        public string IssuedBy { get; set; }
        public string AvailableToJoinInDays { get; set; }
        public string CurrentEmployerSector { get; set; }
        public string ExperienceYears { get; set; }
        public string ExperienceMonths { get; set; }
        public string SkillName { get; set; }
        public string CurrentJobtitle { get; set; }
        public string CurrentCompanyname { get; set; }
        public string Pastjobtitle { get; set; }
        public string PastFrom { get; set; }
        public string PastTo { get; set; }
        public string Pastcompanyname { get; set; }
        public string DiscriptionNotes { get; set; }
        public string DisabilityType { get; set; }
        public string UDIDOption { get; set; }
        public string UDIDNumber { get; set; }
        public string DisabilityPercentage { get; set; }
        public string UDIDCardName { get; set; }
    }
}
