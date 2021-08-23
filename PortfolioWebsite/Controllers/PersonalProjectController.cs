using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PortfolioWebsite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalProjectController : ControllerBase
    {
        private static readonly string[] Names = new[]
        {
            "Shared Drive Automation", "Backup Audit", "VictorsLink Mobile", "ArdPI Weather"
        };
        private static readonly string[] Summaries = new[]
        {
            "BCBSM", "BCBSM", "Personal", "Personal"
        };
        private static readonly string ExampleBody = "This is the body of the personal project";

        private readonly ILogger<PersonalProjectController> _logger;

        public PersonalProjectController(ILogger<PersonalProjectController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<PersonalProject> Get()
        {
            var rng = new Random();
            return Enumerable.Range(0, 4).Select(index => new PersonalProject
            {
                Date = DateTime.Now.AddDays(index),
                Name = Names[index],
                Summary = Summaries[index],
                Body = ExampleBody
            })
            .ToArray();
        }
    }
}