using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
    public class Turno
    {
        public int TurnoId { get; set; }
        public char TipoTurno { get; set; }

        ////relaciones clases       

        public List<Persona> Personas { get; set; }
        public Turno()
        {
            Personas = new List<Persona>();
        }

       
    }
}
