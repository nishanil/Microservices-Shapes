using Microsoft.EntityFrameworkCore;

namespace Circles.Models
{
    public class CircleContext : DbContext 
    {
        public CircleContext(DbContextOptions<CircleContext> options): base(options)
        {
            
        }
        public DbSet<Circle> Circles { get; set; }
    } 
}