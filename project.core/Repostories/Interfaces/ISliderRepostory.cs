using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Repostories.Interfaces
{
    public interface ISliderRepostory
    {
        Task CreateAsync(Slider slider);
        Task<Slider> GetByIdAsync(int id);
        Task<List<Slider>> GetAllAsync();
        void Delete(Slider slider);
        Task<int> CommitAsync();
    }
}
