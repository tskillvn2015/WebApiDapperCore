using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiDapperCore.Data.Interface;
using WebApiDapperCore.Data.Models;
using WebApiDapperCore.Filters;
using WebApiDapperCore.Models;

namespace WebApiDapperCore.Controllers
{
    
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/Products
        [HttpGet]
        [Route("api/Products")]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> GetAll()
        {
            var rs = await _productService.GetAll();
            return Ok(rs);
        }
        // GET: api/paging
        [HttpGet]
        [Route("api/paging")]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> GetPaging(string keyword,int pageIndex,int pageSize)
        {
            var rs = await _productService.GetPaging(keyword,pageIndex,pageSize);
            return Ok(rs);
        }
        // GET: api/Product/5
        [HttpGet]
        [Route("api/Product")]
        [Authorize(Roles = "0,1")]
        public async Task<IActionResult> GetAsync([FromQuery]int id)
        {
            var rs = await _productService.GetById(id);
            return Ok(rs);
        }

        // POST: api/Product
        [HttpPost]
        [Route("api/Product")]
        [Authorize(Roles = "1")]
        [ValidateModel]
        public async Task<IActionResult> Post([FromBody]Product model)
        {
            var rs = await _productService.CreateProduct(model);
            return Ok(rs);
        }

        // PUT: api/Product/5
        [HttpPut]
        [Route("api/Product")]
        [Authorize(Roles = "1")]
        [ValidateModel]
        public async Task<IActionResult> Put([FromBody]Product model)
        {
            await _productService.Update(model);
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        [Route("api/Product")]
        [Authorize(Roles = "1")]
        public async Task<IActionResult> Delete([FromQuery]int id)
        {
            await _productService.Delete(id);
            return Ok();
        }
    }
}
