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
    public class BookRepository : GenericRepostory<Book>, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context)
        {
        }
    }
}
