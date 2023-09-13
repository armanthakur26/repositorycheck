using imageupload.Models;
using Microsoft.EntityFrameworkCore;

namespace imageupload.Data
{
    public class Applicationdbcontext:DbContext
    {
        public Applicationdbcontext(DbContextOptions<Applicationdbcontext> options) : base(options)
        {
            
        }
        public DbSet<Image> images { get; set; }
        public DbSet<buses> Buses { get; set; }
        public DbSet<car> cars { get; set; }
        public DbSet<bikes> Bikes { get; set; }
    }
}
