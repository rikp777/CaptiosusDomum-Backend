using Api.Dal.Entities.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Interface.Core
{
    public interface ILightContext
    {
        bool Log(LightEntity lightEntity);
        Task<List<LightEntity>> GetLog();
    }
}
