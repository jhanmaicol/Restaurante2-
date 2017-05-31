using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class CartaConfiguration : EntityTypeConfiguration<Carta>
    {
        public CartaConfiguration()
        {
            //Table Configurations
            ToTable("CartasDelDia");
            HasKey(c => c.CartaId);

            ////Relations Configurations

            HasRequired(c => c.EspecialidadDia)
                .WithMany(c => c.Cartas);
            //.HasForeignKey(c => c.EspecialidadDiaId);        }
        }
    }
}
