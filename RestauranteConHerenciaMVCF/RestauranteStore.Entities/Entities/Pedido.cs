using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
  public  class Pedido
    {
        public int PedidoId { get; set; }
        public int CantidadPlato { get; set; }
        public string Extra { get; set; }
        public double MontoPagar { get; set; }

        ////relaciones clases       
        public List<PlatoComida> PlatosComidas { get; set; }

        public Pedido()
        {
           
            PlatosComidas = new List<PlatoComida>();
        }

        public int PersonaId { get; set; }
        public Persona Persona { get; set; }      

        public int EstadoPedidoId { get; set; }
        public EstadoPedido EstadoPedido { get; set; }

   



    }
}
