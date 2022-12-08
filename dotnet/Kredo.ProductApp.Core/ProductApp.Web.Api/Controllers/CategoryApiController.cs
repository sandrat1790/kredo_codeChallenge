
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductApp.Models.Domain;
using ProductApp.Models.Requests.Category;
using ProductApp.Services;
using ProductApp.Services.Interfaces;
using ProductApp.Web.Controllers;
using ProductApp.Web.Models.Responses;
using System;
using System.Collections.Generic;

namespace ProductApp.Web.Api.Controllers
{
    [Route("api/category")]
    [ApiController]
    [AllowAnonymous]

    public class CategoryApiController : BaseApiController
    {
        private ICategoryService _service = null;
        private IProductService _pservice;
        private IAuthenticationService<int> _authservice = null;

        public CategoryApiController(ICategoryService service
            , IProductService pservice
            , ILogger<CategoryApiController> logger
            , IAuthenticationService<int> authservice) : base(logger)
        {
            _service = service;
            _pservice = pservice;
            _authservice = authservice;
        }

        [HttpPost]
        public ActionResult<ItemResponse<string>> Add(CategoryAddRequest model)
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
        public ActionResult<SuccessResponse> Update(CategoryUpdateRequest model)
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
        public ActionResult<ItemResponse<Category>> GetById(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                Category category = _service.GetById(id);

                if (category == null)
                {
                    code = 404;
                    response = new ErrorResponse("Record not found");
                }
                else
                {
                    response = new ItemResponse<Category> { Item = category };
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

        [HttpGet]
        public ActionResult<ItemsResponse<Category>> GetAll()
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                List<Category> list = _service.GetAll();

                if (list.Count == 0)
                {
                    code = 404;
                    response = new ErrorResponse("Record not found");
                }
                else
                {
                    response = new ItemsResponse<Category> { Items = list };
                }
            }
            catch (Exception ex)
            {
                code = 500;
                response = new ErrorResponse(ex.Message);
                base.Logger.LogError(ex.ToString());
            }
            return StatusCode(code, response);
        }

        [HttpGet("{id:int}/products")]
        public ActionResult<ItemsResponse<Product>> GetByCategoryId(int id)
        {
            int code = 200;
            BaseResponse response = null;

            try
            {
                List<Product> list = _pservice.GetByCategoryId(id);

                if (list == null)
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
