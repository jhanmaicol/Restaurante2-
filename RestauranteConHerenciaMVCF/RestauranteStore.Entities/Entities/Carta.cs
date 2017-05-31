using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
    public class Carta
    {
        public int CartaId { get; set; }
        public int Bebidas { get; set; }
        public int Menu { get; set; }
        public int Postres { get; set; }

        //relaciones clases

        public int EspecialidadDiaId { get; set; }
        public EspecialidadDia EspecialidadDia { get; set; } 


           public List<Persona> Personas { get; set; }

             public Carta()

             {
                 Personas = new List<Persona>();                 
             }

         
     
    }
}
