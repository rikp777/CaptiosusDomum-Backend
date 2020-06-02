using Api.Api.EntityModels.Climate;
using Api.Dal.Entities.Core;
using Api.Logic.Interfaces;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClimateController : ControllerBase
    {
        private readonly IClimateService _climateLogic;

        public ClimateController(IClimateService climateService)
        {
            _climateLogic = climateService;
        }

        [HttpPost("create")]
        public async Task<JsonResult> Create(ClimateEntityModel climate)
        {
            return new JsonResult(await _climateLogic.Add(new Climate(0, climate.Name)));
        }

        [HttpPost("delete")]
        public async Task<JsonResult> Delete(ClimateEntityModel climate)
        {
            return new JsonResult(await _climateLogic.Delete(climate.Id));
        }

        [HttpPost("update")]
        public async Task<JsonResult> Update(ClimateEntityModel climate)
        {
            return new JsonResult(await _climateLogic.Update(new Climate(climate.Id, climate.Name)));
        }

        [HttpPost("get")]
        public async Task<JsonResult> Get()
        {
            return new JsonResult(await _climateLogic.Get());
        }
    }
}
