using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApp.Models.Domain;
using ProductApp.Models.Requests.Product;
using ProductApp.Services;
using ProductApp.Services.Interfaces;
using ProductApp.Web.Controllers;
using ProductApp.Web.Models.Responses;
using System;
using System.Collections.Generic;

namespace ProductApp.Web.Api.Controllers
{
    [Route("api/product")]
    [ApiController]
    [AllowAnonymous]

    public class ProductApiController : BaseApiController
    {
        private IProductService _service = null;
        private IAuthenticationService<int> _authservice = null;

        public ProductApiController(IProductService service
            , ILogger<ProductApiController> logger
            , IAuthenticationService<int> authservice) : base(logger)
        {
            _service = service;
            _authservice = authservice;
        }

        [HttpPost]
        public ActionResult<ItemResponse<string>> Add(ProductAddRequest model)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Add(model);
                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpPut("{id:int}")]
        public ActionResult<SuccessResponse> Update(ProductUpdateRequest model)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Update(model);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpDelete("{id:int}")]
        public ActionResult<SuccessResponse> Delete(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                _service.Delete(id);

                response = new SuccessResponse();
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ItemResponse<Product>> GetById(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                Product product = _service.GetById(id);

                if (product == null)
                {
                    code = 404;
                    response = new ErrorResponse("Record not found");
                }
                else
                {
                    response = new ItemResponse<Product> { Item = product };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                Logger.LogError(ex.ToString());
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        }


        [HttpGet("{make:alpha}")]
        public ActionResult<ItemsResponse<Product>> GetByMake(string make)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                List<Product> list = _service.GetByMake(make);

                if (list.Count == 0)
                {
                    code = 404;
                    response = new ErrorResponse("Record not found");
                }
                else
                {
                    response = new ItemsResponse<Product> { Items = list };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                Logger.LogError(ex.ToString());
                response = new ErrorResponse(ex.Message);
            }
            return StatusCode(code, response);
        } 


    }
}
