using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestauranteStore.Entities.Entities;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class IngredienteConfiguration : EntityTypeConfiguration<Ingrediente>
    {
        public IngredienteConfiguration()
        {
            //Table Configurations
            ToTable("Ingredientes");
            HasKey(c => c.IngredienteId);

            ////Relations Configurations

            HasRequired(c => c.Almacen)
            .WithMany(c => c.Ingredientes)
             .HasForeignKey(c => c.AlmacenId);

            HasRequired(c => c.PlatoComida)
                .WithMany(c => c.Ingredientes);
                //.HasForeignKey(c => c.PlatoComidaId);      


        }

    }
}
