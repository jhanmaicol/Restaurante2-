using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
  public  class EstadoPedido
    {
        public int EstadoPedidoId { get; set; }
        public char Devuelto { get; set; }
        public char Pagado { get; set; }
        public char PorPagar { get; set; }
        public int TipoPago { get; set; }

        ////relaciones clases   

        public List<Pedido> Pedidos { get; set; }

        public EstadoPedido()
        {
            Pedidos = new List<Pedido>();
            
        }
    }
}
