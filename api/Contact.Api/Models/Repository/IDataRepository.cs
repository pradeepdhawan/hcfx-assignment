using System.Collections.Generic;

namespace Contact.Api.Models.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();

        TEntity Get(long id);

        void Add(TEntity entity);

        void Update(Contact contact, TEntity entity);

        void Delete(Contact contact);
    }
}