using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class TipoEmpleadoConfiguration : EntityTypeConfiguration<TipoEmpleado>
    {
        public TipoEmpleadoConfiguration()
        {
            //Table Configurations
            ToTable("TipoEmpleados");
            HasKey(c => c.TipoEmpleadoId);

            ////Relations Configurations
            HasMany(c => c.Personas)
                 .WithRequired(c => c.TipoEmpleado);
                // .HasForeignKey(c => c.TipoEmpleadoId);

            
        }

    }
}
