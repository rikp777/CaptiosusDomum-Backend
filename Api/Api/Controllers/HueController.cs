using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Logic.Hue.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HueController : ControllerBase
    {
        private readonly IHueService _hueLogic;

        public HueController(IHueService hueLogic)
        {
            _hueLogic = hueLogic;
        }

        [HttpGet("DiscoverBridge")]
        public async Task<JsonResult> Discover()
        {
            return new JsonResult(await _hueLogic.DiscoverBridgesAsync());
        }

        [HttpPost("RegisterBridge")]
        public async Task<JsonResult> RegisterBridge(string BridgeIp)
        {
            return new JsonResult(await _hueLogic.RegisterHueBridge(BridgeIp));
        }

        [HttpGet("FindHueLights")]
        public async Task<JsonResult> FindHueLights()
        {
            throw new NotImplementedException();
        }
    }
}