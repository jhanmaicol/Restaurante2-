using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class ReservaConfiguration : EntityTypeConfiguration<Reserva>
    {
        public ReservaConfiguration()
        {
            //Table Configurations
            ToTable("Reservas");
            HasKey(c => c.ReservaId);

            ////Relations Configurations
            HasRequired(c => c.Persona)
                .WithRequiredPrincipal(c => c.Reserva);

            HasRequired(c => c.Mesa)
                .WithMany(c => c.Reservas);
              //  .HasForeignKey(c => c.MesaId);

        }

    }
}
