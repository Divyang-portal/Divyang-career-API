using Dapper;
using DivyangCareerApi.Dapper;
using DivyangCareerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace DivyangCareerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        public readonly IDapper _dapper;
        public CandidateController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpPost(nameof(AddCandidate))]
        public async Task<Message<int>> AddCandidate([FromBody] CandidateSignUp Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 1);
                pram.Add("FirstName", Model.FirstName);
                pram.Add("LastName", Model.LastName);
                pram.Add("Username", Model.Username);
                pram.Add("Email", Model.Email);
                pram.Add("PhoneNumber", Model.PhoneNumber);
                pram.Add("CountryCode", Model.CountryCode);
                pram.Add("Password", Model.Password);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpPost(nameof(CheckUserName))]
        public async Task<Message<int>> CheckUserName([FromBody] CheckUserName Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 2);
                pram.Add("Username", Model.UserName);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpGet(nameof(logindata))]
        public async Task<Message<CandidateSignUp>> logindata(string email, string password)
        {
            Message<CandidateSignUp> message = new Message<CandidateSignUp>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 3);
                param.Add("Email", email);
                param.Add("Password", password);
                message.Data = await Task.FromResult(_dapper.Get<CandidateSignUp>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "InvalidEmailOrPassword";
            }
            return message;
        }
        [HttpPost(nameof(ChangeCandidatePassword))]
        public async Task<Message<int>> ChangeCandidatePassword([FromBody] ChangePassword Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 6);
                pram.Add("Email", Model.Email);
                pram.Add("Password", Model.CurrentPassword);
                pram.Add("ConfirmPassword", Model.NewPassword);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpGet(nameof(GetUserDetails))]
        public async Task<Message<UserProfile>> GetUserDetails(string email)
        {
            Message<UserProfile> message = new Message<UserProfile>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 7);
                param.Add("Email", email);
                message.Data = await Task.FromResult(_dapper.Get<UserProfile>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "InvalidEmailOrPassword";
            }
            return message;
        }
        [HttpPost(nameof(UpdateCandidateDetails))]
        public async Task<Message<int>> UpdateCandidateDetails([FromBody] UserProfile Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 8);
                pram.Add("FirstName", Model.FirstName);
                pram.Add("LastName", Model.LastName);
                pram.Add("PhoneNumber", Model.PhoneNumber);
                pram.Add("CountryCode", Model.CountryCode);
                pram.Add("GuardianName", Model.GuardianName);
                pram.Add("Description", Model.Description);
                pram.Add("CandidateIds", Model.CandidateId);
                pram.Add("DBO", Model.DBO);
                pram.Add("ProfileImage", Model.ProfileImage);
                pram.Add("Gender", Model.Gender);
                pram.Add("PrimaryLanguage", Model.PrimaryLanguage);
                pram.Add("Address", Model.Address);
                pram.Add("EmploymentStatus", Model.EmploymentStatus);
                pram.Add("State", Model.State);
                pram.Add("District", Model.District);
                pram.Add("SubDistrict", Model.SubDistrict);
                pram.Add("AddressType", Model.AddressType);
                pram.Add("TerritoryTypes", Model.TerritoryTypes);
                pram.Add("PinCode", Model.PinCode);
                pram.Add("MaritalStatus", Model.MaritalStatus);
                pram.Add("Religions", Model.Religions);
                pram.Add("Castes", Model.Castes);
                pram.Add("UIDType", Model.UIDType);
                pram.Add("UIDNumber", Model.UIDNumber);
                pram.Add("CVName", Model.CVName);
                pram.Add("Cities", Model.Cities);
                pram.Add("AddressSubType", Model.AddressSubType);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Error";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpGet(nameof(GetLanguage))]
        public async Task<Message<List<Language>>> GetLanguage()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 9);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetGender))]
        public async Task<Message<List<Gender>>> GetGender()
        {
            Message<List<Gender>> message = new Message<List<Gender>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 10);
                message.Data = await Task.FromResult(_dapper.GetAll<Gender>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetEmploymentStatus))]
        public async Task<Message<List<Language>>> GetEmploymentStatus()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 11);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(BindSubDistrict))]
        public async Task<Message<List<SubDistrict>>> BindSubDistrict(string StateId, string DistrictId)
        {
            Message<List<SubDistrict>> message = new Message<List<SubDistrict>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 12);
                param.Add("StateId", StateId);
                param.Add("DistrictId", DistrictId);
                message.Data = await Task.FromResult(_dapper.GetAll<SubDistrict>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetAddressType))]
        public async Task<Message<List<Gender>>> GetAddressType()
        {
            Message<List<Gender>> message = new Message<List<Gender>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 13);
                message.Data = await Task.FromResult(_dapper.GetAll<Gender>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetAddressSubType))]
        public async Task<Message<List<Gender>>> GetAddressSubType()
        {
            Message<List<Gender>> message = new Message<List<Gender>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 14);
                message.Data = await Task.FromResult(_dapper.GetAll<Gender>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetTerritoryTypes))]
        public async Task<Message<List<Gender>>> GetTerritoryTypes()
        {
            Message<List<Gender>> message = new Message<List<Gender>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 15);
                message.Data = await Task.FromResult(_dapper.GetAll<Gender>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetMaritalStatus))]
        public async Task<Message<List<Language>>> GetMaritalStatus()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 16);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetReligions))]
        public async Task<Message<List<Language>>> GetReligions()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 17);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetCastes))]
        public async Task<Message<List<Gender>>> GetCastes()
        {
            Message<List<Gender>> message = new Message<List<Gender>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 18);
                message.Data = await Task.FromResult(_dapper.GetAll<Gender>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetUIDType))]
        public async Task<Message<List<Language>>> GetUIDType()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 19);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetHighestEducationAttained))]
        public async Task<Message<List<Language>>> GetHighestEducationAttained()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 20);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetEducation))]
        public async Task<Message<List<Language>>> GetEducation(string HighestEducationAttainedID)
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 21);
                param.Add("HighestEducationAttained", HighestEducationAttainedID);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetSpecializations))]
        public async Task<Message<List<Language>>> GetSpecializations(string EducationID)
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 22);
                param.Add("EducationID", EducationID);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetBoardUniversities))]
        public async Task<Message<List<Language>>> GetBoardUniversities()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 23);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetMonth))]
        public async Task<Message<List<Language>>> GetMonth()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 24);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(BindCities))]
        public async Task<Message<List<Cities>>> BindCities(string StateId, string District, string SubDistrict)
        {
            Message<List<Cities>> message = new Message<List<Cities>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 25);
                param.Add("StateId", StateId);
                param.Add("DistrictId", District);
                param.Add("SubDistrict", SubDistrict);
                message.Data = await Task.FromResult(_dapper.GetAll<Cities>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetGradeTypesOptions))]
        public async Task<Message<List<Language>>> GetGradeTypesOptions()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 26);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpGet(nameof(GetCourseNature))]
        public async Task<Message<List<Gender>>> GetCourseNature()
        {
            Message<List<Gender>> message = new Message<List<Gender>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 27);
                message.Data = await Task.FromResult(_dapper.GetAll<Gender>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpPost(nameof(EducationUpdateCandidateDetails))]
        public async Task<Message<int>> EducationUpdateCandidateDetails([FromBody] CandidateEducationDetails Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 28);
                pram.Add("CandidateIds", Model.CandidateId);
                pram.Add("HighestEducationAttained", Model.HighestEducationAttained);
                pram.Add("EducationQualification", Model.EducationQualification);
                pram.Add("Specializations", Model.Specializations);
                pram.Add("BoardUniversities", Model.BoardUniversities);
                pram.Add("Institute", Model.Institute);
                pram.Add("Month", Model.Month);
                pram.Add("Years", Model.Years);
                pram.Add("GradePercentagePercentileType", Model.GradePercentagePercentileType);
                pram.Add("GradePercentagePercentileValue", Model.GradePercentagePercentileValue);
                pram.Add("CourseNature", Model.CourseNature);
                pram.Add("MediumOfEducation", Model.MediumOfEducation);
                pram.Add("CertificateName", Model.CertificateName);
                pram.Add("CertificateYear", Model.CertificateYear);
                pram.Add("IssuedBy", Model.IssuedBy);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Error";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpGet(nameof(GetCurrentEmployerSector))]
        public async Task<Message<List<Language>>> GetCurrentEmployerSector()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 29);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpPost(nameof(ExperienceUpdateCandidateDetails))]
        public async Task<Message<int>> ExperienceUpdateCandidateDetails([FromBody] CandidateExperienceDetails Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 30);
                pram.Add("CandidateIds", Model.CandidateId);
                pram.Add("AvailableToJoinInDays", Model.AvailableToJoinInDays);
                pram.Add("CurrentEmployerSector", Model.CurrentEmployerSector);
                pram.Add("ExperienceYears", Model.ExperienceYears);
                pram.Add("ExperienceMonths", Model.ExperienceMonths);
                pram.Add("SkillName", Model.SkillName);
                pram.Add("CurrentJobtitle", Model.CurrentJobtitle);
                pram.Add("CurrentCompanyname", Model.CurrentCompanyname);
                pram.Add("Pastjobtitle", Model.Pastjobtitle);
                pram.Add("PastFrom", Model.PastFrom);
                pram.Add("PastTo", Model.PastTo);
                pram.Add("Pastcompanyname", Model.Pastcompanyname);
                pram.Add("DiscriptionNotes", Model.DiscriptionNotes);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Error";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpGet(nameof(GetDisabilityType))]
        public async Task<Message<List<Language>>> GetDisabilityType()
        {
            Message<List<Language>> message = new Message<List<Language>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 31);
                message.Data = await Task.FromResult(_dapper.GetAll<Language>("Usp_Candidate", param));
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data != null)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Success";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = "some error";
            }
            return message;
        }
        [HttpPost(nameof(DisabilityUpdateCandidateDetails))]
        public async Task<Message<int>> DisabilityUpdateCandidateDetails([FromBody] CandidateDisablityInfoDetails Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 32);
                pram.Add("CandidateIds", Model.CandidateId);
                pram.Add("DisabilityType", Model.DisabilityType);
                pram.Add("UDIDOption", Model.UDIDOption);
                pram.Add("UDIDNumber", Model.UDIDNumber);
                pram.Add("DisabilityPercentage", Model.DisabilityPercentage);
                pram.Add("UDIDCardName", Model.UDIDCardName);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = "Error";
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
        [HttpPost(nameof(CheckEmailUpdate))]
        public async Task<Message<int>> CheckEmailUpdate([FromBody] CheckEmail Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 33);
                pram.Add("Email", Model.Email);
                pram.Add("CurrentEmail", Model.CurrentEmail);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Candidate", pram));
                var status = Convert.ToString(pram.Get<string>("@Result"));
                message.ReturnMessage = status;
            }
            catch (Exception ex)
            {
                message.ReturnMessage = ex.Message;
            }
            if (message.Data == 1)
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            else
            {
                message.IsSuccess = true;
                message.ReturnMessage = message.ReturnMessage;
            }
            return message;
        }
    }
}
