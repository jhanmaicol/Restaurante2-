using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class PedidoConfiguration : EntityTypeConfiguration<Pedido>
    {
        public PedidoConfiguration()
        {
            //Table Configurations
            ToTable("Pedidos");
            HasKey(c => c.PedidoId);

            ////Relations Configurations


            HasMany(c => c.PlatosComidas)
                .WithRequired(c => c.Pedido);
            // .HasForeignKey(c => c.PedidoId);

            HasRequired(c => c.EstadoPedido)
                .WithMany(c => c.Pedidos)
                .HasForeignKey(c => c.EstadoPedidoId); 
                        
        }

    }
}
