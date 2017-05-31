using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class EspecialidadDiaConfiguration : EntityTypeConfiguration<EspecialidadDia>
    {
        public EspecialidadDiaConfiguration()
        {
            //Table Configurations
            ToTable("EspecialidadDias");
            HasKey(c => c.EspecialidadDiaId);

            //Relations Configurations
            HasMany(c => c.Cartas)
                .WithRequired(c => c.EspecialidadDia);
               //.HasForeignKey(c => c.EspecialidadDiaId);


        }

    }
}
