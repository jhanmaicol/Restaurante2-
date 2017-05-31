using RestauranteStore.Entities.Entities;
using RestauranteStore.Entities.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Persistence.Repositories
{
    public class PersonaRepository : Repository<Persona>, IPersonaRepository
    {
        private readonly RestauranteStoreDbContext _Context;

        public PersonaRepository(RestauranteStoreDbContext context)
        {
            _Context = context;
        }

        private PersonaRepository()
        {

        }
    }
}
