using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IEntityService<TEntity, TId>
        where TEntity : class, IEntity, new()
    {
        IResult Add(TEntity entity);
        IResult Delete(TEntity entity);
        IResult Update(TEntity entity);
        IDataResult<List<TEntity>> GetAll();
        IDataResult<TEntity> GetById(TId id);
    }
}
