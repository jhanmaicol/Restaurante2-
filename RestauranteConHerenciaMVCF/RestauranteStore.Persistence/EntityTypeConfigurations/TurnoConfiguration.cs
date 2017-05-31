using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
   public class TurnoConfiguration : EntityTypeConfiguration<Turno>
    {
        public  TurnoConfiguration()
        {
            //Table Configurations
            ToTable("Turnos");
            HasKey(c => c.TurnoId);

            ////Relations Configurations
            HasMany(c => c.Personas)
                .WithRequired(c => c.Turno);
              // .HasForeignKey(c => c.TurnoId);
            
        }

    }
}
