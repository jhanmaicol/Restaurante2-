using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
   public class Reserva
    {
        public int ReservaId { get; set; }

        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }

        ////relaciones clases

        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

        public int MesaId { get; set; }
        public Mesa Mesa { get; set; }
    }

    

}
