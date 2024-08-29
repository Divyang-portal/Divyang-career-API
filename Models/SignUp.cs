using System.ComponentModel.DataAnnotations;

namespace DivyangCareerApi.Models
{
    public class SignUp
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string UserType { get; set; }
        public string CountryCode { get; set; }
    }
}
