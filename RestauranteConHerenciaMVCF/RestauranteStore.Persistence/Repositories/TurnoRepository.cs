using RestauranteStore.Entities.Entities;
using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class TurnoRepository : Repository<Turno>, ITurnoRepository
    {
        private readonly RestauranteStoreDbContext _Context;

        public TurnoRepository(RestauranteStoreDbContext context)
        {
            _Context = context;
        }

        private TurnoRepository()
        {

        }
    }
}
