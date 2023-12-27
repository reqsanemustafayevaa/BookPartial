using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Interfaces
{
    public interface ISliderService
    {
        Task CreatAsync(Slider slider);
        Task DeleteAsync(int id);  //repositoryden ferqli(*Task)
        Task<List<Slider>> GetAllAsync();
        Task<Slider> GetAsync(int id);
        Task UpdateAsync(Slider slider);
    }
}
