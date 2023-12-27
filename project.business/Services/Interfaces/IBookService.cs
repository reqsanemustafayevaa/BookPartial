using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IBookService
    {
        Task CreateAsync(Book book);
        Task UpdateAsync(Book book);
        Task Delete(int id);
        Task<List<Book>> GetAllAsync(Expression<Func<Book, bool>>? expression = null);
        Task<Book> GetByIdAsync(int id);

    }
}
