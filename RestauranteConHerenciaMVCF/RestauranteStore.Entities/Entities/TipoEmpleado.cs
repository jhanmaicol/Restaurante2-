using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
   public class TipoEmpleado
    {
        public int TipoEmpleadoId { get; set; }
        public string NomTipoEmp { get; set; }

        ////relaciones clases       

        public List<Persona> Personas { get; set; }

        public TipoEmpleado()
        {
            Personas = new List<Persona>();
        }


    }
}
