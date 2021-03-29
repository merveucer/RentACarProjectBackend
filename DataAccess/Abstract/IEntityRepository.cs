using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    // where -> Generic constraint oluşturur.
    // class -> T, reference type olmalıdır.
    // IEntity -> T, IEntity veya IEntity'den implemente edilen bir nesne olmalıdır.
    // new() -> T, new'lenebilmelidir. Bununla birlikte, IEntity yazımını engellemiş olduk ve sadece IEntity'nin referans tutuculuğundan yararlanarak onu implemente eden nesneleri yazılabilir duruma getirdik.
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // filter=null -> Filtre verilmeyebilir.
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
