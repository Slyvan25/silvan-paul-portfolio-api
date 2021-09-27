using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SilvanPaulPortfolioAPI.Models;

namespace SilvanPaulPortfolioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NavItemsController : ControllerBase
    {
        private readonly ILogger<NavItemsController> _logger;

        public NavItemsController(ILogger<NavItemsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<NavigationItems> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new NavigationItems
            {
                Id = rng.Next(0, 100),
                Name = "item",
                Hidden = false,
                Disabled = false,
                reference = "/home"
            })
            .ToArray();
        }
    }
}
