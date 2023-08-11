using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EduGrowthMonitor.Data;
using System;
using System.Linq;
using Microsoft.JSInterop.Infrastructure;

namespace EduGrowthMonitor.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EduGrowthMonitorContext (
                serviceProvider.GetRequiredService<DbContextOptions<EduGrowthMonitorContext>>()))
            {
                // Look for any Data Entry
                if(context.EduProgressRecord.Any())
                {
                    return; // DB has been seeded
                }
                context.EduProgressRecord.AddRange(
                    new EduProgressRecord
                    {
                        Emp_ID = 1,
                        Domain = "Dot Net",
                        Date = DateTime.Parse("2023-01-01"),
                        Task = "Web Technologies",
                        Deatils = "Learning... HTML, CSS, JS",
                        Hours = 5,
                        Comments = "In Progress..."
                    },
                    new EduProgressRecord
                    {
                        Emp_ID = 2,
                        Domain = "Dot Net",
                        Date = DateTime.Parse("2023-01-01"),
                        Task = "Web Technologies",
                        Deatils = "Learning [Intermediate]... HTML, CSS, JS",
                        Hours = 5,
                        Comments = "In Progress..."
                    },
                    new EduProgressRecord
                    {
                        Emp_ID = 3,
                        Domain = "Dot Net",
                        Date = DateTime.Parse("2023-01-01"),
                        Task = "JavaScript",
                        Deatils = "Learning... JS",
                        Hours = 4,
                        Comments = "In Progress..."
                    },
                    new EduProgressRecord
                    {
                        Emp_ID = 4,
                        Domain = "Dot Net",
                        Date = DateTime.Parse("2023-01-01"),
                        Task = "StyleSheet",
                        Deatils = "CSS",
                        Hours = 4,
                        Comments = "In Progress..."
                    },
                    new EduProgressRecord
                    {
                        Emp_ID = 5,
                        Domain = "Dot Net",
                        Date = DateTime.Parse("2023-01-01"),
                        Task = "C#",
                        Deatils = "Learning from scratch",
                        Hours = 5,
                        Comments = "In Progress..."
                    }
                    );
                    context.SaveChanges();
            }

        }
    }
}
