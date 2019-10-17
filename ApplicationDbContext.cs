using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShinobiRanks1._0.Data;

namespace ShinobiRanks1._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShinobiRanks1._0.Data.HVillage> HVillage { get; set; }
        public DbSet<ShinobiRanks1._0.Data.HVScrolls> HVScrolls { get; set; }
        public DbSet<ShinobiRanks1._0.Data.HVKage> HVKage { get; set; }
        public DbSet<ShinobiRanks1._0.Data.HVJounin> HVJounin { get; set; }
        public DbSet<ShinobiRanks1._0.Data.HVChuunin> HVChuunin { get; set; }
        public DbSet<ShinobiRanks1._0.Data.HVGenin> HVGenin { get; set; }
    }
}
