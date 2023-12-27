using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface ITagService
    {
        Task CreateAsync(Tag tag);
        Task UpdateAsync(Tag tag);
        Task<Tag> GetByIdAsync(int id);
        Task<List<Tag>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
