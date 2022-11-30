using BL;
using Domains;
using EaglesProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EaglesProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeightCategoryApiController : ControllerBase
    {
        WeightCategoryService weightCategoryService;
        ItemCategoryService itemCategoryService;
        EaglesDatabaseContext ctx;
        public WeightCategoryApiController(WeightCategoryService WeightCategoryService,ItemCategoryService ItemCategoryService, EaglesDatabaseContext context)
        {
            itemCategoryService = ItemCategoryService;
            ctx = context;
            weightCategoryService = WeightCategoryService;

        }
        // GET: api/<WeightCategoryApiController>
        [HttpGet]
        public IEnumerable<TbWeightCategory> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstWeightCategories = weightCategoryService.getAll();
            return model.lstWeightCategories;
        }

        // GET api/<WeightCategoryApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeightCategoryApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeightCategoryApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeightCategoryApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
