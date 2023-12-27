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
    public class BookImagesRepository : GenericRepostory<BookImage>, IBookImagesRepository
    {
        public BookImagesRepository(AppDbContext context) : base(context)
        {
        }
    }
}
