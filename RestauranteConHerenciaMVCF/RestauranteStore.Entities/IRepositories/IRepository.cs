using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestauranteStore.Entities.IRepositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        //metodos estandar que todas las tablas deben de tener.
        //Creates
        void Add(TEntity entity);

        void AddRange(IEnumerable<TEntity> entities);
        //Reads
        TEntity Get(int? Id);
        IEnumerable<TEntity> GetAll();
        IEnumerator<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        //Update
        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);
        //Deletes
        void Delete(TEntity entity);

        void DeleteRange(IEnumerable<TEntity> entities);

    }
}
