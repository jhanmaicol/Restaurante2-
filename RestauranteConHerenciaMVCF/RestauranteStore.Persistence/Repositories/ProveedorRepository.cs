using RestauranteStore.Entities.Entities;
using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    class ProveedorRepository : Repository<Proveedor>, IProveedorRepository
    {
        private readonly RestauranteStoreDbContext _Context;

        public ProveedorRepository(RestauranteStoreDbContext context)
        {
            _Context = context;
        }

        private ProveedorRepository()
        {

        }
    }
}
