using Core.Entities;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public interface IEntityService<TEntity> where TEntity : class, IEntity
    {
        IDataResult<List<TEntity>> GetAll();
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
        
    }
}
