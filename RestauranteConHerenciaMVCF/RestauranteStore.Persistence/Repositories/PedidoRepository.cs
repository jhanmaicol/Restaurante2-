using RestauranteStore.Entities.Entities;
using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class PedidoRepository : Repository<Pedido>, IPedidoRepository
    {
        private readonly RestauranteStoreDbContext _Context;

        public PedidoRepository(RestauranteStoreDbContext context)
        {
            _Context = context;
        }

        private PedidoRepository()
        {

        }
    }
}
