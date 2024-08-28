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
    public class EmployeeController : ControllerBase
    {
        public readonly IDapper _dapper;
        public EmployeeController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpPost(nameof(AddEmployee))]
        public async Task<Message<int>> AddEmployee([FromBody] SignUp Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                string type = Model.Type;
                pram.Add("Mode", 1);
                pram.Add("FirstName", Model.Firstname);
                pram.Add("LastName", Model.Lastname);
                pram.Add("UserName", Model.Username);
                pram.Add("Email", Model.Email);
                pram.Add("PhoneNumber", Model.PhoneNumber);
                pram.Add("CountryCode", Model.CountryCode);
                pram.Add("Password", Model.Password);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Employee", pram));
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
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Employee", pram));
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
        [HttpPost(nameof(CheckEmail))]
        public async Task<Message<int>> CheckEmail([FromBody] CheckEmail Model)
        {
            Message<int> message = new Message<int>();
            var pram = new DynamicParameters();
            try
            {
                pram.Add("Mode", 5);
                pram.Add("Username", Model.Email);
                pram.Add("Result", dbType: DbType.String, size: 200, direction: ParameterDirection.Output);
                message.Data = await Task.FromResult(_dapper.Post<int>("Usp_Employee", pram));
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
        public async Task<Message<EmployerDetails>> logindata(string email, string password)
        {
            Message<EmployerDetails> message = new Message<EmployerDetails>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 3);
                param.Add("Email", email);
                param.Add("Password", password);
                message.Data = await Task.FromResult(_dapper.Get<EmployerDetails>("Usp_Employee", param));
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
    }
}
