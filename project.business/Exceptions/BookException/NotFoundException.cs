using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions.BookException
{
    public class NotFoundException:Exception
    {
        public string PropertyName {  get; set; }
        public NotFoundException()
        {
            
        }
        public NotFoundException(string propertyname,string message):base(message)
        {
            PropertyName = propertyname;
        }
        
    }
}
