using System;
using System.Collections.Generic;
using System.Text;
using Actio.Common.Events;

namespace Actio.Common.Commands
{
    public class CreateUserRejected: IRejectedEvent
    {
        public string Email { get; set; }
        public string Reason { get; }
        public string Code { get; }

        protected CreateUserRejected()
        {
            
        }

        public CreateUserRejected(string email, string code, string reason)
        {
            Email = email;
            Reason = reason;
            Code = code;
        }
    }
}
