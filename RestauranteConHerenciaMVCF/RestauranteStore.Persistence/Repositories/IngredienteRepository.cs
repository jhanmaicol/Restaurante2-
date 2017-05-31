using RestauranteStore.Entities.Entities;
using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class IngredienteRepository : Repository<Ingrediente>, IIngredienteRepository
    {
        private readonly RestauranteStoreDbContext _Context;

        public IngredienteRepository(RestauranteStoreDbContext context)
        {
            _Context = context;
        }

        private IngredienteRepository()
        {

        }
    }
}
