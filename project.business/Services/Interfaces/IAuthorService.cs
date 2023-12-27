using Microsoft.EntityFrameworkCore;
using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IAuthorService
    {
       
        Task CreateAsync(Author author);
        Task<Author> GetByIdAsync(int id);
        Task Delete(int id);
        Task<List<Author>> GetAllAsync();
        Task UpdateAsync(Author author);
    }
}
