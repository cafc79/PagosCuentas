using Microsoft.EntityFrameworkCore;
using PAT.Models.Database.Stores;
using PAT.Models.Database.Tablas;

namespace PAT.Infrastructure.Context;

public class PATContext : DbContext
{
    public DbSet<ABCJwtTokenUsuario> UserTokens { get; set; } = default!;
    public DbSet<ABCPagos> ABCPagos { get; set; } = default!;
    public DbSet<ABCCuentasPorPagar> ABCCuentasPorPagar { get; set; } = default!;
    public DbSet<ABCEstatusCuentasXPagar> ABCEstatusCuentasXPagar { get; set; } = default!;
    public DbSet<ABCEmpresa> ABCEmpresa { get; set; } = default!;
    public DbSet<ABCProveedor> ABCProveedor { get; set; } = default!;
    public DbSet<ABCAutorizacionPago> ABCAutorizacionPago { get; set; } = default!;
    public DbSet<ABCAutorizador> ABCAutorizador { get; set; } = default!;
    public DbSet<VWABCHistorialPago> VWABCHistorialPago { get; set; } = default!;
    public DbSet<VWABCAutorizacionPago> VWABCAutorizacionPago { get; set; } = default!;
    public DbSet<VWABCCuentasXPagar> VWABCCuentasXPagar { get; set; } = default!;
    public DbSet<VWABCIndicadoresEgresos> VWABCIndicadoresEgresos { get; set; } = default!;
    public PATContext(DbContextOptions<PATContext> options) : base(options)
    {
       
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //StoresProcedures
       modelBuilder.Entity<StpABCProcesaAutorizacionPago>().HasNoKey();
        modelBuilder.Entity<StpABCRechazaAutorizacionPago>().HasNoKey();
        
        modelBuilder.Entity<VWABCGetStatusSemaforo>().HasNoKey();
        modelBuilder.Entity<VWABCIndicadoresEgresos>().HasNoKey();
        modelBuilder.Entity<VWABCRolPermiso>().HasNoKey();
        modelBuilder.Entity<VWABCRolSemaforo>().HasNoKey();
        


    }
    }
