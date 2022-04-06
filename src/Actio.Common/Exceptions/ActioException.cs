using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;
using System.Text;

namespace Actio.Common.Exceptions
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

        public ActioException(string message, params object[] args) : this(message)
        {
        }

        public ActioException(string code, string message) : this(code, new Exception(message))
        {
        }
    }
}
