using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
    public class CancelarReserva
    {
        public int CancelarReservaId { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public int NumMesa { get; set; }

        //relaciones clases
              
         public int PersonaID { get; set; }
         public Persona Persona { get; set; }

     
       
    }
}
