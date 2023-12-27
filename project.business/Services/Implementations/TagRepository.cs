using project.business.Services.Interfaces;
using project.core.Models;
using project.data.DAL;
using project.data.Repostories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Services.Implementations
{
    public class TagRepository : GenericRepostory<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext context) : base(context)
        {
        }
    }
}
