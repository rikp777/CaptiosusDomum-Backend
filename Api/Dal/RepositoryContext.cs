using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Threading.Tasks;
using Api.Dal.Entities;
using Api.Dal.Entities.Core;

namespace Api.Dal
{
    public class RepositoryContext: DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
        : base(options)
        { }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<HueBridgeEntity> HueBridge { get; set; }
        public DbSet<LightEntity> Light { get; set; }
        public DbSet<ClimateEntity> Climate { get; set; }
        public DbSet<RoomEntity> Room { get; set; }
    }
}
