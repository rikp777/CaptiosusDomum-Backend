using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using Api.Dal.Entities;

namespace Api.Dal
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        { }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<HueBridgeEntity> HueBridge { get; set; }
    }
}
