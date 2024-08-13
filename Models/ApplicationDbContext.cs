using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

namespace ImageuploadingandRetrive.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options ):base(options)
        { }

        public DbSet<Uploadimage> uploadimages { get; set; }
    }
}
