using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
  public  class PlatoComida
    {
        public int PlatoComidaId { get; set; }
        public string NomPlato { get; set; }
        public double Precio { get; set; }

        ////relaciones clases
   
        public List<Ingrediente> Ingredientes { get; set; }

        public PlatoComida()
        {
            
            Ingredientes = new List<Ingrediente>();
        }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }

    }
}
