using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
    public class Proveedor 
    {
        public int ProveedorId { get; set; }

        public string NombreEmpresa { get; set; }
        public int Ruc { get; set; }

        ////relaciones clases       

        public int AlmacenId { get; set; }
        public Almacen Almacen { get; set; }

    }
}
