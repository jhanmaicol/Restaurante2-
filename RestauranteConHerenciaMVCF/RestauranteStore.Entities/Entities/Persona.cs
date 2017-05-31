using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.Entities
{
    public abstract class Persona
    {
        public int PersonaId { get; set; }
        public int DNI { get; set; }
        public string NombrePersona { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public char Sexo { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public Persona() : base()
        {

            Pedidos = new List<Pedido>();

        }
        public int CartaId { get; set; }
        public Carta Carta { get; set; }

        public int CancelarReservaId { get; set; }
        public CancelarReserva CancelarReserva { get; set; }

        public int ReservaId { get; set; }
        public Reserva Reserva { get; set; }      

        public int TipoEmpleadoId { get; set; }
        public TipoEmpleado TipoEmpleado { get; set; }

        public int TurnoId { get; set; }
        public Turno Turno { get; set; }

   









    }
}
