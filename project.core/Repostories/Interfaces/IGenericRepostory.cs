using Microsoft.EntityFrameworkCore;
using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Repostories.Interfaces
{
    public interface IGenericRepostory<TEntity>where TEntity : BaseEntity, new()
    {
        public DbSet<TEntity> Table {  get; }  //_context.set
        Task CreateAsync(TEntity entity);
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);  
        Task<TEntity>GetByIdAsync(Expression<Func<TEntity, bool>>? expression = null, params string[]? includes);

        void Delete(TEntity entity);
        Task<int>CommitAsync( );

    }
}
