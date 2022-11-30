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
    public class SettingsApiController : ControllerBase
    {
        SettingService settingService;
        ItemCategoryService itemCategoryService;
        EaglesDatabaseContext ctx;
        public SettingsApiController(SettingService SettingService,ItemCategoryService ItemCategoryService, EaglesDatabaseContext context)
        {
            itemCategoryService = ItemCategoryService;
            ctx = context;
            settingService = SettingService;

        }
        // GET: api/<SettingsApiController>
        [HttpGet]
        public IEnumerable<TbSetting> Get()
        {
            HomePageModel model = new HomePageModel();
            model.lstSettings = settingService.getAll();
            return model.lstSettings;
        }

        // GET api/<SettingsApiController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SettingsApiController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SettingsApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SettingsApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
