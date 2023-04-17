using BingoWasm.Server.Services;
using BingoWasm.Shared.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BingoWasm.Server.Controllers
{
    
    [ApiController]
    public class BingoController : ControllerBase
    {
        private readonly BingoService _service;

        public BingoController(BingoService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            ResponseData data = new();
            try
            {
                data.MainData = _service.GetBingoAllList();
            }
            catch( Exception ex)
            {
                data.Message = ex.Message;
            }

            return new JsonResult(data);
        }
    }
}
