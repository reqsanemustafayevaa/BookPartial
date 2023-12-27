using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidContentTypeExceptions:Exception
    {
        public string PropertyName {  get; set; }
        public InvalidContentTypeExceptions()
        {
            
        }
        public InvalidContentTypeExceptions(string propertyName,string message):base(message) 
        {

            PropertyName = propertyName;

        }
    }
}
