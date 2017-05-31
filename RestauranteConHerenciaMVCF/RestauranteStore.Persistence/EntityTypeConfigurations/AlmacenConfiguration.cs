using RestauranteStore.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.EntityTypeConfigurations
{
    public class AlmacenConfiguration : EntityTypeConfiguration <Almacen>
    {
        public  AlmacenConfiguration()
        {
            //Table Configurations
            ToTable("Almacen");
            HasKey(c => c.AlmacenId);


            ////Relations Configurations
            HasMany(c => c.Ingredientes)
              .WithRequired(c => c.Almacen);
            //.HasForeignKey(c => c.AlmacenId);

            HasMany(c => c.Proveedores)
                .WithRequired(c => c.Almacen);
               //.HasForeignKey(c => c.AlmacenId);






        }






    }
}
