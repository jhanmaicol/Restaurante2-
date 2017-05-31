using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
  public  class Ingrediente
    {
        public int IngredienteId { get; set; }
        public int Cantidad { get; set; }
        public char EstadoIngrediente { get; set; }
        public string NombreIng { get; set; }
        public int TipoIng { get; set; }

        ////relaciones clases       

        public int PlatoComidaId { get; set; }
        public PlatoComida PlatoComida { get; set; }

        public int AlmacenId { get; set; }
        public Almacen Almacen { get; set; }


    }
}
