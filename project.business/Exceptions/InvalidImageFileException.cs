using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidImageFileException:Exception
    {
        public  string PropertyName { get; set; }
        public InvalidImageFileException()
        {
            
        }
        public InvalidImageFileException(string propertyName,string message):base(message) 
        {

            PropertyName = propertyName;

        }
    }
}
