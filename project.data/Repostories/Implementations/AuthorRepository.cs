using Microsoft.EntityFrameworkCore;
using project.core.Models;
using project.core.Repostories.Interfaces;
using project.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace project.data.Repostories.Implementations
{

    public class AuthorRepository : GenericRepostory<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context)
        {
        }

        
    }
}
