using System;
using System.Collections.Generic;

namespace VouDeVan.Core.Business.Support
{
    public interface IRepository<T>
    {
        void Store(T entity);
        void Update(T entity);

        T GetById(Guid id);

        IList<T> GetAll();

        bool HasById(Guid id);
    }
}
