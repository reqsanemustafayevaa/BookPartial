using project.business.Exceptions;
using project.business.Services.Interfaces;
using project.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public async Task CreateAsync(Tag tag)
        {
            if(_tagRepository.Table.Any(x=>x.Name == tag.Name && x.Id != tag.Id))
            {
                throw new InvalidNullReferenceException("Name", "Tag already exist!");
            }
            _tagRepository.CreateAsync(tag);
            await _tagRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _tagRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted==false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            _tagRepository.Delete(entity);
            await _tagRepository.CommitAsync();
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _tagRepository.GetAllAsync();
        }

        public async Task<Tag> GetByIdAsync(int id)
        {
            var entity= await _tagRepository.GetByIdAsync(x => x.Id == id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            return entity;
           
        }

        public async Task UpdateAsync(Tag tag)
        {
            var entity = await _tagRepository.GetByIdAsync(x => x.Id == tag.Id && x.IsDeleted == false);
            if (entity == null)
            {
                throw new NullReferenceException();
            }
            if (_tagRepository.Table.Any(x => x.Name == tag.Name && x.Id != tag.Id))
            {
                throw new InvalidNullReferenceException("Name","Tag already exist!");
                
            }
            entity.Name = tag.Name;
            await _tagRepository.CommitAsync();
        }
    }
}
