using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroService.IApplication.Product;
using MicroService.IApplication.Product.Dto;
using Microsoft.AspNetCore.Mvc;

namespace TestWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IGoodsAppService _goodsAppService;
        public ValuesController(IGoodsAppService goodsAppService)
        {
            _goodsAppService = goodsAppService;
        }
        // GET api/values
        [HttpPost("GetList")]
        public async Task<object> GetList(GoodsoPageRequestDto goodsoPageRequestDto)
        {
            return await _goodsAppService.GetPageListAsync(goodsoPageRequestDto);
           // return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        [HttpGet]
        public async Task<object> Get()
        {
            GoodsoPageRequestDto goodsoPageRequestDto = new GoodsoPageRequestDto();
            var sb= await _goodsAppService.GetPageListAsync(goodsoPageRequestDto);
            return await  Task.FromResult(sb);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
