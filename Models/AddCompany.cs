using System.Web.Mvc;

namespace DivyangCareerApi.Models
{
    public class AddCompany
    {
        public int Id { get; set; }
        public string EmployerId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyCategories { get; set; }
        [AllowHtml]
        public string CompanyAboutUs { get; set; }
        public string CompanyWebsite { get; set; }
        public string PhoneNumber { get; set; }
        public string CompanyEmail { get; set; }
        public string FoundedIn { get; set; }
        public string CompanySize { get; set; }
        public string CompanyLogo { get; set; }
        public string CompanyCoverImages { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkdinUrl { get; set; }
        public string FaceBookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string GalleryImage { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string CompanyFullAddress { get; set; }
        public string PhoneCountryCode { get; set; }
    }
}
