using Api.Dal.Interface.Core;
using Api.Logic.Interfaces;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Logic.Services
{
    public class ClimateService : IClimateService
    {
        private readonly IClimateContext _climateContext;


        public ClimateService(IClimateContext climateContext)
        {
            _climateContext = climateContext;
        }

        public Task<Climate> Add(Climate climate)
        {
            return _climateContext.Add(climate);
        }

        public Task<bool> Delete(int id)
        {
            return _climateContext.Delete(id);
        }

        public Task<List<Climate>> Get()
        {
            return _climateContext.Get();
        }

        public Task<Climate> Update(Climate climate)
        {
            return _climateContext.Update(climate);
        }
    }
}
