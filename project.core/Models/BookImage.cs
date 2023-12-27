using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Models
{
    public class BookImage: BaseEntity   //book-bookimage   one to many
    {
        public string ImageUrl {  get; set; }
        public bool? IsPoster {  get; set; }  //null 3 cu hal ucun
        public int BookId {  get; set; }
        public Book? Book { get; set; }
    }
}
