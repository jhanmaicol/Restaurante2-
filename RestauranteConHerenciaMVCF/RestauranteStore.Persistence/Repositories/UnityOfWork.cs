using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly RestauranteStoreDbContext _Context;
        private static UnityOfWork _Instance;
        private static readonly object _Lock = new object();

        public IAlmacenRepository Almacen { get; private set; }

        public ICancelarReservaRepository CancelarReserva { get; private set; }

        public ICartaRepository Carta { get; private set; }

        public IClienteRepository Cliente { get; private set; }

        public IEmpleadoRepository Empleado { get; private set; }

        public IEspecialidadDiaRepository EspecialidadDias { get; private set; }

        public IEstadoPedidoRepository EstadoPedido { get; private set; }

        public IIngredienteRepository Ingrediente { get; private set; }

        public IMesaRepository Mesa { get; private set; }

        public IPedidoRepository Pedido { get; private set; }

        public IPersonaRepository Persona { get; private set; }

        public IPlatoComidaRepository PlatoComida { get; private set; }

        public IProveedorRepository Proveedor { get; private set; }

        public IReservaRepository Reserva { get; private set; }

        public ITipoEmpleadoRepository TipoEmpleado { get; private set; }

        public ITurnoRepository Turno { get; private set; }

        private UnityOfWork()
        {
            _Context = new RestauranteStoreDbContext();

            Almacen = new AlmacenRepository(_Context);
            CancelarReserva = new CancelarReservaRepository(_Context);
            Carta = new CartaRepository(_Context);
            EspecialidadDias = new EspecialidadDiaRepository(_Context);
            EstadoPedido = new EstadoPedidoRepository(_Context);
            Ingrediente = new IngredienteRepository(_Context);
            Mesa = new MesaRepository(_Context);
            Pedido = new PedidoRepository(_Context);
            Persona = new PersonaRepository(_Context);
            PlatoComida = new PlatoComidaRepository(_Context);
            Reserva = new ReservaRepository(_Context);
            TipoEmpleado = new TipoEmpleadoRepository(_Context);
            Turno = new TurnoRepository(_Context);


        }

        public static UnityOfWork Instance
        {
            get
            {
                lock (_Lock)
                {
                    if (_Instance == null)
                        _Instance = new UnityOfWork();
                }

                return _Instance;

            }
        }

        public void Dispose()
        {
            _Context.Dispose();
        }

        public int SaveChanges()
        {
            return _Context.SaveChanges();
        }

        public void StateModified(object Entity)
        {
            _Context.Entry(Entity).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
