using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kachok.Infrastructure
{
    public class FieldMappingException : Exception
    {
        public FieldMappingException(string fieldName, string message)
            :base(message)
        {
            FieldName = fieldName;
        }
        public string FieldName { get; set; }

    }
}
