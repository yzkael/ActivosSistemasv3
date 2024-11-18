using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ActivosSistemasv3.Models;

    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext (DbContextOptions<DbContext> options)
            : base(options)
        {
        }

        public DbSet<ActivosSistemasv3.Models.Usuario> Usuario { get; set; } = default!;

public DbSet<ActivosSistemasv3.Models.Procesador> Procesador { get; set; } = default!;

public DbSet<ActivosSistemasv3.Models.Memoria> Memoria { get; set; } = default!;

public DbSet<ActivosSistemasv3.Models.DiscoDuro> DiscoDuro { get; set; } = default!;
    }
