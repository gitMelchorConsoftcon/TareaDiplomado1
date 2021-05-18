using Microsoft.EntityFrameworkCore;
using TareaDiplomado.Models;

namespace TareaDiplomado.Db
{
    public class Datos : DbContext
    {
        public DbSet<Cuentas> Cuentas { get; set; }
        public DbSet<Movimientos> Movimientos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Conexion = @"Server =(LocalDb)\MSSQLLocalDB;
                                Database = TareaDipolomado;
                               integrated security=true";
           

            optionsBuilder.UseSqlServer(Conexion);

        }
    }
}
