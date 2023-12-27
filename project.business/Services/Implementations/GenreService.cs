using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Models;
using project.core.Repostories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task CreateAsync(Genre genre)
        {
            var existgenre=await _genreRepository.GetByIdAsync(x=>x.Id==genre.Id);
            if(_genreRepository.Table.Any(x=> x.Name == genre.Name ))
            {
                throw new InvalidNullReferenceException("Name","Genre already exist!");
            }
            await _genreRepository.CreateAsync(genre);
            await _genreRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            var existgenre=await _genreRepository.GetByIdAsync(x => x.Id == id);
            if (existgenre == null)
            {
                throw new NullReferenceException();
            }
             _genreRepository.Delete(existgenre);
            await _genreRepository.CommitAsync();



        }

        public async Task<List<Genre>> GetAllAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> GetByIdAsync(int id)
        {
            var existgenre = await _genreRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted==false);
            if (existgenre == null)
            {
                throw new NullReferenceException();
            }

            return existgenre;
        }

        public async Task UpdateAsync(Genre genre)
        {
            var existgenre = await _genreRepository.GetByIdAsync(x => x.Id == genre.Id);
            if (existgenre == null)
            {
                throw new NullReferenceException();
            }
            if(_genreRepository.Table.Any(x=>x.Name == genre.Name && x.Id != genre.Id)) 
            {
                throw new InvalidNullReferenceException("Name","Genre already exist!");

            }
            existgenre.Name = genre.Name;
            await _genreRepository.CommitAsync();
        }
    }
}
