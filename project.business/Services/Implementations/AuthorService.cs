using Microsoft.EntityFrameworkCore;
using project.business.Services.Interfaces;
using project.core.Models;
using project.core.Repostories.Interfaces;
using project.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
       

        public AuthorService(IAuthorRepository authorRepository,AppDbContext context)
        {
            _authorRepository = authorRepository;
            
        }

        

        public async Task CreateAsync(Author author)
        {
            if(author == null)
            {
                throw new NullReferenceException();
            }
            
            await _authorRepository.CreateAsync(author);
            await _authorRepository.CommitAsync();
        }

        public async Task Delete(int id)
        {
            
            var entity = await _authorRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if(entity == null)
            {
                throw new NullReferenceException();
            }
            _authorRepository.Delete(entity);
            await _authorRepository.CommitAsync();
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var entity = await _authorRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity is null) throw new NullReferenceException();
            return entity;
        }

        public async Task UpdateAsync(Author author)
        {
            var existentity = await _authorRepository.GetByIdAsync(x => x.Id == author.Id && x.IsDeleted == false);
            if (_authorRepository.Table.Any(x => x.FullName == author.FullName && existentity.Id!=author.Id))
            {
                throw new NullReferenceException();
            }
            existentity.FullName = author.FullName;
            await _authorRepository.CommitAsync();
        }
    }
}
