using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PorftolioCoreProject_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainPageController : Controller
    {
        private IMainPageService _mainPageService;

        public MainPageController(IMainPageService mainPageService)
        {
            _mainPageService = mainPageService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _mainPageService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int MainPageId)
        {
            var result = _mainPageService.GetById(MainPageId);
            return Ok(result);
        }

        [HttpPost("addmainpage")]
        public IActionResult AddAnnouncement(MainPage mainPage)
        {
            _mainPageService.Add(mainPage);
            return Ok();
        }

        [HttpDelete("deletemainpage")]
        public IActionResult DeleteAnnouncement(MainPage mainPage)
        {
            _mainPageService.Delete(mainPage);
            return Ok();
        }

        [HttpPost("updatemainpage")]
        public IActionResult UpdateAnnouncement(MainPage mainPage)
        {
            _mainPageService.Update(mainPage);
            return Ok();
        }
    }
}
