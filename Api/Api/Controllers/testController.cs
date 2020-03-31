using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Api.Services.Logger;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class testController : Controller
    {
        private readonly ILoggerManager _logger;

        public testController(ILoggerManager logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            _logger.LogInfo("Here is info message from the controller.");
            _logger.LogDebug("Here is debug message from the controller.");
            _logger.LogWarn("Here is warn message from the controller.");
            _logger.LogError("Here is error message from the controller.");

            return new string[] { "value1", "value2" };
        }
    }
}