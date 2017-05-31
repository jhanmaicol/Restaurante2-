using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    class ProveedorCofigurations : EntityTypeConfiguration<Proveedor>
    {
        public ProveedorCofigurations()
        {
            //Table Configurations
            ToTable("Provedores");
            HasKey(c => c.ProveedorId);

            HasRequired(c => c.Almacen)
           .WithMany(c => c.Proveedores)
            .HasForeignKey(c => c.AlmacenId);

        }
    }
}
