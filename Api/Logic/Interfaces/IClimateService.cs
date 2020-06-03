using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Logic.Interfaces
{
    public interface IClimateService
    {
        Task<Climate> Add(Climate climate);
        Task<bool> Delete(int id);
        Task<Climate> Update(Climate climate);
        Task<List<Climate>> Get();
    }
}
