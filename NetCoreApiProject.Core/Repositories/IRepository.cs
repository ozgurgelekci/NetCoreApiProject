using System;
using System.Collections.Generic;
using System.Text;
using NetCoreApiProject.Core.Entities.Abstract;

namespace NetCoreApiProject.Core.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {

    }
}
