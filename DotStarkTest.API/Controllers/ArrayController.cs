using DotStarkTest.Core.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotStarkTest.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ArrayController : ControllerBase
    {
        [HttpPost]
        [Route("getArray")]
        public IActionResult GetArray([FromBody] List<ArrayObjVM> arrObj)
        {
            ResponseVM response = new ResponseVM
            {
                Status = false,
                Message = "Bed request",
                StatusCode = HTTPStatusCode.BadRequest
            };
            var model = new List<ArrayObjVM>();
            try
            {
                var query = arrObj.Where(x => x.body.Contains("minima"));

                model = query.Select(x => new ArrayObjVM { 
                    id = x.id,
                    userId = x.userId,
                    title = x.title,
                    body = x.body
                }).ToList();

                response.Message = "Success";
                response.Status = true;
                response.StatusCode = HTTPStatusCode.OK;
                response.Data = model;
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                response.StatusCode = HTTPStatusCode.CatchException;
            }
            return Ok(response);
        }
    }
}
