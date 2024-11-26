using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MinhasNotas.Models;

namespace MinhasNotas.Data
{
    public class MinhasNotasContext : DbContext
    {
        public MinhasNotasContext (DbContextOptions<MinhasNotasContext> options)
            : base(options)
        {
        }

        public DbSet<MinhasNotas.Models.Student> Student { get; set; } = default!;

        public DbSet<MinhasNotas.Models.Teacher>? Teacher { get; set; }

        public DbSet<MinhasNotas.Models.Subject>? Subject { get; set; }

        public DbSet<MinhasNotas.Models.Grades>? Grades { get; set; }
    }
}
