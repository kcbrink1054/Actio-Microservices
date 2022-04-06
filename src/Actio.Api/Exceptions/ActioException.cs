using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Actio.Api.Exceptions
{
    public class ActioException: Exception
    {
        public string Code { get; }

        public ActioException()
        {
            
        }

        public ActioException(string code)
        {
            Code = code;
        }
    }
}
