using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class PlatoComidaConfiguration : EntityTypeConfiguration<PlatoComida>
    {
        public PlatoComidaConfiguration()
        {
            //Table Configurations
            ToTable("PlatoComidas");
            HasKey(c => c.PlatoComidaId);

            HasMany(c => c.Ingredientes)
                .WithRequired(c => c.PlatoComida);
            //.HasForeignKey(c => c.PlatoComidaId);

            HasRequired(c => c.Pedido)
                .WithMany(c => c.PlatosComidas);
               // .HasForeignKey(c => c.PedidoId);
        }

    }
}
