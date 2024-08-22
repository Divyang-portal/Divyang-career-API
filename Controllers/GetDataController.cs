using Dapper;
using DivyangCareerApi.Dapper;
using DivyangCareerApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DivyangCareerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDataController : ControllerBase
    {
        public readonly IDapper _dapper;
        public GetDataController(IDapper dapper)
        {
            _dapper = dapper;
        }
        [HttpGet(nameof(GetAllLeadData))]
        public async Task<Message<List<Jobs>>> GetAllLeadData()
        {
            Message<List<Jobs>> message = new Message<List<Jobs>>();
            var param = new DynamicParameters();
            try
            {
                param.Add("Mode", 1);
                message.Data = await Task.FromResult(_dapper.GetAll<Jobs>("Usp_DivyangData", param));
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
