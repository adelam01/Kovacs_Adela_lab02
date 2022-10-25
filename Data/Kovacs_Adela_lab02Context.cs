using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kovacs_Adela_lab02.Models;

namespace Kovacs_Adela_lab02.Data
{
    public class Kovacs_Adela_lab02Context : DbContext
    {
        public Kovacs_Adela_lab02Context (DbContextOptions<Kovacs_Adela_lab02Context> options)
            : base(options)
        {
        }

        public DbSet<Kovacs_Adela_lab02.Models.Book> Book { get; set; } = default!;

        public DbSet<Kovacs_Adela_lab02.Models.Publisher> Publisher { get; set; }

        public DbSet<Kovacs_Adela_lab02.Models.Author> Author { get; set; }
    }
}
