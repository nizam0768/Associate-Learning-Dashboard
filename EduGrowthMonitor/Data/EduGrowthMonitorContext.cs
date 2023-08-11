using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EduGrowthMonitor.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace EduGrowthMonitor.Data
{
    public class EduGrowthMonitorContext : IdentityDbContext
    {
        public EduGrowthMonitorContext (DbContextOptions<EduGrowthMonitorContext> options)
            : base(options)
        {
        }

        public DbSet<EduGrowthMonitor.Models.EduProgressRecord> EduProgressRecord { get; set; } = default!;
    }
}
