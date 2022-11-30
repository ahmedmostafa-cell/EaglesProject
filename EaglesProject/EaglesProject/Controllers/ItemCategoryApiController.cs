using BL;
using Domains;
using EaglesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EaglesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryApiController : ControllerBase
    {
        ItemCategoryService itemCategoryService;
        EaglesDatabaseContext ctx;
        public ItemCategoryApiController(ItemCategoryService ItemCategoryService, EaglesDatabaseContext context)
        {
            itemCategoryService = ItemCategoryService;
            ctx = context;

        }
        // GET: api/<ItemCategoryApiController>
        [HttpGet]
        public IEnumerable<VwWeightPrice> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstVwWeightPrices = ctx.VwWeightPrices.ToList();
            return model.lstVwWeightPrices;
        }

        // GET api/<ItemCategoryApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ItemCategoryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ItemCategoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemCategoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
