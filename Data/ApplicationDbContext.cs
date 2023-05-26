using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElizabethRobinsonDiaryEntries.Models;

namespace ElizabethRobinsonDiaryEntries.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ElizabethRobinsonDiaryEntries.Models.DiaryEntries>? DiaryEntries { get; set; }
    }
}