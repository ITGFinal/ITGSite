using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ITGFinal.Models
{
    public class SoundContext : DbContext
    {
        public DbSet<Sound> Users { get; set; }
        public SoundContext(DbContextOptions<SoundContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
