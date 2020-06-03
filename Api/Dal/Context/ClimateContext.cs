using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Dal.Entities.Core;
using Api.Dal.Interface.Core;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Dal.Context
{
    public class ClimateContext : IClimateContext
    {
        private RepositoryContext _context;

        public ClimateContext(RepositoryContext context)
        {
            _context = context;
        }

        public async Task<Climate> Add([FromBody] Climate climate)
        {
            ClimateEntity newclimate = new ClimateEntity(climate.Id, climate.Name);
            await _context.Climate.AddAsync(newclimate);
            await _context.SaveChangesAsync();

            if (await _context.Climate.ContainsAsync(newclimate))
            {
                return climate;
            }
            return null;
        }


        public async Task<bool> Delete([FromForm]int id)
        {
            var climateEntity = await _context.Climate.FirstOrDefaultAsync(o => o.Id == id);

            await _context.SaveChangesAsync();

            if (await _context.Climate.ContainsAsync(climateEntity))
            {
                return false;
            }
            return true;
        }

        public async Task<List<Climate>> Get()
        {
            List<Climate> climates = new List<Climate>();
            List<ClimateEntity> climateEntities = await _context.Climate.ToListAsync();
            foreach (var climate in climateEntities)
            {
                //hier willen we eventueel nog gegevens van het apparaat mee opvragen
                //nog niet geïmplementeerd
                climates.Add(new Climate(climate.Id, climate.Name));
            }
            return climates;
        }

        public async Task<Climate> Update([FromBody]Climate climate)
        {
            var editedobject = await _context.Climate.FirstOrDefaultAsync(o => o.Id == climate.Id);
            await _context.SaveChangesAsync();

            return climate;
        }
    }
}
