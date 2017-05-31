using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class MesaConfiguration : EntityTypeConfiguration<Mesa>
    {
        public MesaConfiguration()
        {
            //Table Configurations
            ToTable("Mesas");
            HasKey(c => c.MesaId);

            ////Relations Configurations

            HasMany(c => c.Reservas)
                .WithRequired(c => c.Mesa);
              // .HasForeignKey(c => c.MesaId);
        }

    }
}
