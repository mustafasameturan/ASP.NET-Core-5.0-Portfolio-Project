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
    public class ServiceController : Controller
    {
        private IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _serviceService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int ServiceId)
        {
            var result = _serviceService.GetById(ServiceId);
            return Ok(result);
        }

        [HttpPost("addservice")]
        public IActionResult AddAnnouncement(Service service)
        {
            _serviceService.Add(service);
            return Ok();
        }

        [HttpDelete("deleteservice")]
        public IActionResult DeleteAnnouncement(Service service)
        {
            _serviceService.Delete(service);
            return Ok();
        }

        [HttpPost("updateservice")]
        public IActionResult UpdateAnnouncement(Service service)
        {
            _serviceService.Update(service);
            return Ok();
        }
    }
}
