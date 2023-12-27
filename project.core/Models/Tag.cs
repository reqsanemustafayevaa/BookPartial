using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.core.Models
{
    public class Tag:BaseEntity
    {
        public string? Name {  get; set; }

        public List<BookTag>? BookTags { get; set; }
    }
}
