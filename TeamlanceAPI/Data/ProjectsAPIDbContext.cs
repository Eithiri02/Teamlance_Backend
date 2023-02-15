using Microsoft.EntityFrameworkCore;
using TeamlanceAPI.Models;

namespace TeamlanceAPI.Data
{

    public class ProjectsAPIDbContext : DbContext
    {
        public ProjectsAPIDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
    }
}
