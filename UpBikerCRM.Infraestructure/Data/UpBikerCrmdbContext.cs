using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using UpBikerCRM.Infraestructure.Data.Configurations;
using static UpBikerCRM.Core.Entities.Inventario;

namespace UpBikerCRM.Infraestructure.Data;

public partial class UpBikerCrmdbContext : DbContext
{
    public UpBikerCrmdbContext()
    {
    }

    public UpBikerCrmdbContext(DbContextOptions<UpBikerCrmdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductoConfiguration).Assembly);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
