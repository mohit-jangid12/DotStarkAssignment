using DotStarkTest.Core.Services;
using DotStarkTest.Core.ViewModel;
using DotStarkTest.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DotStarkTest.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductServices _proService;
        private IServiceProvider _serviceProvider;
        public ProductController(IUnitOfWork unitOfWork, IServiceProvider serviceProvider)
        {
            _proService = new ProductServices(unitOfWork);
            _serviceProvider = serviceProvider;
        }
        [Route("getProducts")]
        public IActionResult GetProducts()
        {
            ResponseVM response = new ResponseVM
            {
                Status = false,
                Message = "Bed request",
                StatusCode = HTTPStatusCode.BadRequest
            };
            var model = new List<ProductVM>();
            try
            {
                model = _proService.GetAll();


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

        [HttpPost]
        [Route("getStock")]
        public IActionResult GetAvailableProducts(string ProductID, long stockQty)
        {
            ResponseVM response = new ResponseVM
            {
                Status = false,
                Message = "Bed request",
                StatusCode = HTTPStatusCode.BadRequest
            };
            var IsAvail = false;
            try
            {
                IsAvail = _proService.GetAvailableProducts(ProductID, stockQty);

                if (IsAvail)
                {
                    response.Message = "The order could be fulfilled";
                    response.Status = IsAvail;
                    response.StatusCode = HTTPStatusCode.OK;
                }
                else
                {
                    response.Message = "The order could not be fulfilled";
                    response.Status = IsAvail;
                    response.StatusCode = HTTPStatusCode.OK;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                response.StatusCode = HTTPStatusCode.CatchException;
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("saveProducts")]
        public IActionResult SaveProducts(ProductVM model)
        {
            ResponseVM response = new ResponseVM
            {
                Status = false,
                Message = "Bed request",
                StatusCode = HTTPStatusCode.BadRequest
            };
            var IsValid = false;
            try
            {
                IsValid = _proService.Save(model);
                if (IsValid)
                {
                    if (model.ID > 0)
                    {
                        response.Message = "Data updated successfully";
                        response.Status = true;
                        response.StatusCode = HTTPStatusCode.OK;
                    }
                    else
                    {
                        response.Message = "Data save successfully";
                        response.Status = true;
                        response.StatusCode = HTTPStatusCode.OK;
                    }
                }
                else
                {
                    response.Message = "Something went wrong";
                    response.StatusCode = HTTPStatusCode.CatchException;
                }
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
