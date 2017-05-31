using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
    public class EspecialidadDia
    {
        public int EspecialidadDiaId { get; set; }
        public DateTime Dia { get; set; }

        ////relaciones clases
        public List<Carta> Cartas { get; set; }

         public EspecialidadDia()
         {
             Cartas = new List<Carta>();

         }
        
       

    }

}
