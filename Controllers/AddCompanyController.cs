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
    public class AddCompanyController : ControllerBase
    {
        public readonly IDapper _dapper;
        public AddCompanyController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpPost(nameof(ApplyJob))]
        public async Task<Message<int>> ApplyJob([FromBody] CandidateApplyJob Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 1);
                pram.Add("CandidateId", Model.CandidateId);
                pram.Add("JobId", Model.JobId);
                pram.Add("Email", Model.Email);
                pram.Add("PhoneNumber", Model.PhoneNumber);
                pram.Add("Message", Model.Message);
                pram.Add("Resume", Model.Resume);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_CandidateApplyJobs", pram));
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
        [HttpGet(nameof(CompanyCategories))]
        public async Task<Message<List<CompanyCategories>>> CompanyCategories()
        {
            Message<List<CompanyCategories>> message = new Message<List<CompanyCategories>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 1);
                message.Data = await Task.FromResult(_dapper.GetAll<CompanyCategories>("Usp_Company", param));
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
        [HttpGet(nameof(BindCompanySize))]
        public async Task<Message<List<CompanySize>>> BindCompanySize()
        {
            Message<List<CompanySize>> message = new Message<List<CompanySize>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 2);
                message.Data = await Task.FromResult(_dapper.GetAll<CompanySize>("Usp_Company", param));
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
        [HttpGet(nameof(BindState))]
        public async Task<Message<List<State>>> BindState()
        {
            Message<List<State>> message = new Message<List<State>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 3);
                message.Data = await Task.FromResult(_dapper.GetAll<State>("Usp_Company", param));
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
        [HttpGet(nameof(BindDistrict))]
        public async Task<Message<List<District>>> BindDistrict( string StateId)
        {
            Message<List<District>> message = new Message<List<District>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 4);
                param.Add("StateId", StateId);
                message.Data = await Task.FromResult(_dapper.GetAll<District>("Usp_Company", param));
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
        [HttpPost(nameof(AddNewCompany))]
        public async Task<Message<int>> AddNewCompany([FromBody] AddCompany Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 5);
                pram.Add("EmployerId", Model.EmployerId);
                pram.Add("CompanyName", Model.CompanyName);
                pram.Add("CompanyCategories", Model.CompanyCategories);
                pram.Add("CompanyAboutUs", Model.CompanyAboutUs);
                pram.Add("CompanyWebsite", Model.CompanyWebsite);
                pram.Add("PhoneNumber", Model.PhoneNumber);
                pram.Add("CompanyEmail", Model.CompanyEmail);
                pram.Add("FoundedIn", Model.FoundedIn);
                pram.Add("CompanySize", Model.CompanySize);
                pram.Add("CompanyLogo", Model.CompanyLogo);
                pram.Add("CompanyCoverImages", Model.CompanyCoverImages);
                pram.Add("TwitterUrl", Model.TwitterUrl);
                pram.Add("LinkdinUrl", Model.LinkdinUrl);
                pram.Add("FaceBookUrl", Model.FaceBookUrl);
                pram.Add("InstagramUrl", Model.InstagramUrl);
                pram.Add("GalleryImage", Model.GalleryImage);
                pram.Add("State", Model.State);
                pram.Add("District", Model.District);
                pram.Add("CompanyFullAddress", Model.CompanyFullAddress);
                pram.Add("PhoneCountryCode", Model.PhoneCountryCode);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Company", pram));
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
                message.ReturnMessage = "Success";
            }
            return message;
        }
        [HttpGet(nameof(GetCompanyForListPage))]
        public async Task<Message<List<AddCompany>>> GetCompanyForListPage(string Email)
        {
            Message<List<AddCompany>> message = new Message<List<AddCompany>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 6);
                param.Add("CompanyEmail", Email);
                message.Data = await Task.FromResult(_dapper.GetAll<AddCompany>("Usp_Company", param));
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
        [HttpGet(nameof(DeleteCompany))]
        public async Task<Message<int>> DeleteCompany(string CompanyId)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 7);
                pram.Add("EmployerId", CompanyId);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Company", pram));
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
                message.ReturnMessage = "Success";
            }
            return message;
        }
        [HttpGet(nameof(GetCompanyForEdit))]
        public async Task<Message<AddCompany>> GetCompanyForEdit(string Id)
        {
            Message<AddCompany> message = new Message<AddCompany>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 8);
                param.Add("EmployerId", Id);
                message.Data = await Task.FromResult(_dapper.Get<AddCompany>("Usp_Company", param));
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
        [HttpPost(nameof(UpdateNewCompany))]
        public async Task<Message<int>> UpdateNewCompany([FromBody] AddCompany Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 9);
                pram.Add("EmployerId", Model.EmployerId);
                pram.Add("CompanyName", Model.CompanyName);
                pram.Add("CompanyCategories", Model.CompanyCategories);
                pram.Add("CompanyAboutUs", Model.CompanyAboutUs);
                pram.Add("CompanyWebsite", Model.CompanyWebsite);
                pram.Add("PhoneNumber", Model.PhoneNumber);
                pram.Add("CompanyEmail", Model.CompanyEmail);
                pram.Add("FoundedIn", Model.FoundedIn);
                pram.Add("CompanySize", Model.CompanySize);
                pram.Add("CompanyLogo", Model.CompanyLogo);
                pram.Add("CompanyCoverImages", Model.CompanyCoverImages);
                pram.Add("TwitterUrl", Model.TwitterUrl);
                pram.Add("LinkdinUrl", Model.LinkdinUrl);
                pram.Add("FaceBookUrl", Model.FaceBookUrl);
                pram.Add("InstagramUrl", Model.InstagramUrl);
                pram.Add("GalleryImage", Model.GalleryImage);
                pram.Add("State", Model.State);
                pram.Add("District", Model.District);
                pram.Add("CompanyFullAddress", Model.CompanyFullAddress);
                pram.Add("PhoneCountryCode", Model.PhoneCountryCode);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Company", pram));
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
                message.ReturnMessage = "Success";
            }
            return message;
        }
        [HttpGet(nameof(GetAllCompanyDataForDetails))]
        public async Task<Message<AddCompany>> GetAllCompanyDataForDetails(string Id)
        {
            Message<AddCompany> message = new Message<AddCompany>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 10);
                param.Add("EmployerId", Id);
                message.Data = await Task.FromResult(_dapper.Get<AddCompany>("Usp_Company", param));
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
    }
}
