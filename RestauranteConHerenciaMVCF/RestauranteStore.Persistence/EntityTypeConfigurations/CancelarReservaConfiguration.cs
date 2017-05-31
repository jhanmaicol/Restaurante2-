using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class CancelarReservaConfiguration : EntityTypeConfiguration<CancelarReserva>
    {
        public CancelarReservaConfiguration()
        {
            //Table Configurations
            ToTable("CancelarReservas");
            HasKey(c => c.CancelarReservaId);

            ////Relations Configurations
            HasRequired(c => c.Persona)
                 .WithRequiredPrincipal(c => c.CancelarReserva);


        }  

    }
}
