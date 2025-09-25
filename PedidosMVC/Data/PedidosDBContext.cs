using Microsoft.EntityFrameworkCore;
using PedidosMVC.Models;

namespace PedidosMVC.Data
{
    public class PedidosDbContext : DbContext
    {
        public PedidosDbContext(DbContextOptions<PedidosDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración básica de relaciones (ajusta según tus necesidades)
            base.OnModelCreating(modelBuilder);

            // Ejemplo de relación: un pedido puede tener muchos OrderItems
            // y un OrderItem pertenece a un Order y a un Product
            // (Ajusta si tienes propiedades de navegación en tus modelos)
        }
    }
}
