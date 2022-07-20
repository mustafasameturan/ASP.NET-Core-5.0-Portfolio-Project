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
    public class ContactInformationController : Controller
    {
        private IContactInformationService _contactInformationService;

        public ContactInformationController(IContactInformationService contactInformationService)
        {
            _contactInformationService = contactInformationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _contactInformationService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int ContactInformationId)
        {
            var result = _contactInformationService.GetById(ContactInformationId);
            return Ok(result);
        }

        [HttpPost("addcontactinformation")]
        public IActionResult AddAnnouncement(ContactInformation contactInformation)
        {
            _contactInformationService.Add(contactInformation);
            return Ok();
        }

        [HttpDelete("deletecontactinformation")]
        public IActionResult DeleteAnnouncement(ContactInformation contactInformation)
        {
            _contactInformationService.Delete(contactInformation);
            return Ok();
        }

        [HttpPost("updatecontactinformation")]
        public IActionResult UpdateAnnouncement(ContactInformation contactInformation)
        {
            _contactInformationService.Update(contactInformation);
            return Ok();
        }
    }
}
