using Api.Dal.Entities;
using Api.Dal.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Dal.Context
{
    public class HueBridgeContext: IHueBridgeContext
    {
        private RepositoryContext _context;

        public HueBridgeContext(RepositoryContext context)
        {
            _context = context;
        }

        //public async Task<HueBridgeEntity> getBridgesForUser()
        //{
        //    //return await _context.User.;
        //}
    }
}
