using Microsoft.EntityFrameworkCore;
using Jeremy_Castillo_Ap1_p2.Entidades;

namespace Jeremy_Castillo_Ap1_p2.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Productos> Productos {get; set;}
        public DbSet<ProductosDetalle> ProductosDetalles {get; set;}

        public DbSet<EntradaEmpacado> EntradaEmpacado {get; set;}
        
        public Contexto(DbContextOptions<Contexto> options) : base(options){}

    }
}