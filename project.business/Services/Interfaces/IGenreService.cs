using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface IGenreService
    {
        Task CreateAsync(Genre genre);
        Task UpdateAsync(Genre genre);
        Task Delete(int id);
        Task<List<Genre>> GetAllAsync();
        Task<Genre>GetByIdAsync(int id);
        
    }
}
