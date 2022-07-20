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
    public class PortfolioController : Controller
    {
        private IPortfolioService _portfolioService;
        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _portfolioService.GetList();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int PortfolioId)
        {
            var result = _portfolioService.GetById(PortfolioId);
            return Ok(result);
        }

        [HttpPost("addportfolio")]
        public IActionResult AddAnnouncement(Portfolio portfolio)
        {
            _portfolioService.Add(portfolio);
            return Ok();
        }

        [HttpDelete("deleteportfolio")]
        public IActionResult DeleteAnnouncement(Portfolio portfolio)
        {
            _portfolioService.Delete(portfolio);
            return Ok();
        }

        [HttpPost("updateportfolio")]
        public IActionResult UpdateAnnouncement(Portfolio portfolio)
        {
            _portfolioService.Update(portfolio);
            return Ok();
        }
    }
}
