using Microsoft.EntityFrameworkCore;
using project.core.Models;
using project.core.Repostories.Interfaces;
using project.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.data.Repostories.Implementations
{
    public class SliderRepository : ISliderRepostory
    {
        private readonly AppDbContext _context;

        public SliderRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(Slider slider)
        {
            await _context.Sliders.AddAsync(slider);
        }

        public void Delete(Slider slider)
        {
            _context.Sliders.Remove(slider);
        }

        public async Task<List<Slider>> GetAllAsync()
        {
            return await _context.Sliders.ToListAsync();
        }

        public async Task<Slider> GetByIdAsync(int id)
        {
            return await _context.Sliders.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
