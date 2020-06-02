using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;

namespace Api.Dal.Interface.Core
{
    public interface IClimateContext
    {
        Task<Climate> Add(Climate climate);
        Task<bool> Delete(int id);
        Task<Climate> Update(Climate climate);
        Task<List<Climate>> Get();
    }
}
