using RestauranteStore.Entities;
using RestauranteStore.Entities.Entities;
using RestauranteStore.Persistence.EntityTypeConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence
{
    public class RestauranteStoreDbContext : DbContext
    {
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<CancelarReserva> CancelarReservas { get; set; }
        public DbSet<Carta> Cartas { get; set; }
        //public DbSet<Cliente> Clientes { get; set; }
        //public DbSet<Empleado> Empleados { get; set; }
        public DbSet<EspecialidadDia> EspecialidadDias { get; set; }
        public DbSet<EstadoPedido> EstadoPedidos { get; set; }
        public DbSet<Ingrediente> Ingredientes { get; set; }
        public DbSet<Mesa> Mesas { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<PlatoComida> PlatoComidas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Reserva> Reservas { get; set; }        
        public DbSet<TipoEmpleado> TipoEmpleados { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DbSet<Persona> Personas { get; set; }

        public RestauranteStoreDbContext()
            :base("Restaurante EL GORDO 1")
        {

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new AlmacenConfiguration());
            modelBuilder.Configurations.Add(new CancelarReservaConfiguration());
            modelBuilder.Configurations.Add(new CartaConfiguration());
            modelBuilder.Configurations.Add(new EspecialidadDiaConfiguration());
            modelBuilder.Configurations.Add(new EstadoPedidoConfiguration());
            modelBuilder.Configurations.Add(new IngredienteConfiguration());
            modelBuilder.Configurations.Add(new MesaConfiguration());
            modelBuilder.Configurations.Add(new PedidoConfiguration());
            modelBuilder.Configurations.Add(new PersonaConfiguration());
            modelBuilder.Configurations.Add(new PlatoComidaConfiguration());
            modelBuilder.Configurations.Add(new ReservaConfiguration());            
            modelBuilder.Configurations.Add(new TipoEmpleadoConfiguration());
            modelBuilder.Configurations.Add(new TurnoConfiguration());
            modelBuilder.Configurations.Add(new ProveedorCofigurations());



            base.OnModelCreating(modelBuilder);
        }

    }
}
