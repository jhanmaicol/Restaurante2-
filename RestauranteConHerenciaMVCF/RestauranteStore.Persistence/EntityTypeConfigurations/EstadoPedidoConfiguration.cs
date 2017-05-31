using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class EstadoPedidoConfiguration : EntityTypeConfiguration<EstadoPedido>
    {
        public EstadoPedidoConfiguration()
        {
            //Table Configurations
            ToTable("EstadoPedidos");
            HasKey(c => c.EstadoPedidoId);


            ////Relations Configurations 
            HasMany(c => c.Pedidos)
                .WithRequired(c => c.EstadoPedido);
               //.HasForeignKey(c => c.EstadoPedidoId);

        }

    }
}
