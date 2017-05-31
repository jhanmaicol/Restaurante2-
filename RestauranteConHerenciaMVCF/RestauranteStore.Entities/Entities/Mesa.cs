using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
   public class Mesa
    {
        public int MesaId { get; set; }
        public int Cantidad { get; set; }
        public int NumMesa { get; set; }

        ////relaciones clases      

        public List<Reserva> Reservas { get; set; }

        public Mesa()
        {            
            Reservas = new List<Reserva>();
        }
    }
}
