using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.business.Exceptions
{
    public class InvalidNullReferenceException:Exception
    {
        public string PropertyName {  get; set; }
        public InvalidNullReferenceException()
        {
            
        }
        public InvalidNullReferenceException(string propertyName,string? message):base(message) 
        {
            PropertyName = propertyName;
        }
    }
}
