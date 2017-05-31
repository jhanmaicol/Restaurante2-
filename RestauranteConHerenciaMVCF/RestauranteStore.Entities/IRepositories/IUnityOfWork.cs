using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.IRepositories
{
   public interface IUnityOfWork : IDisposable
    {

        IAlmacenRepository Almacen { get; }
        ICancelarReservaRepository CancelarReserva { get; }
        ICartaRepository Carta { get; }
        IClienteRepository Cliente { get; }
        IEmpleadoRepository Empleado { get; }
        IEspecialidadDiaRepository EspecialidadDias { get; }
        IEstadoPedidoRepository EstadoPedido { get; }
        IIngredienteRepository Ingrediente { get; }
        IMesaRepository Mesa { get; }
        IPedidoRepository Pedido { get; }
        IPersonaRepository Persona { get; }
        IPlatoComidaRepository PlatoComida { get; }
        IProveedorRepository Proveedor { get; }
        IReservaRepository Reserva { get;  }
        ITipoEmpleadoRepository TipoEmpleado { get; }
        ITurnoRepository Turno { get; }

        int SaveChanges();
        void StateModified(object entity);

    }
}
