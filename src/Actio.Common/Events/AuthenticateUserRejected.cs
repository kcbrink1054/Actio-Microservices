using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Events
{
    public class AuthenticateUserRejected: IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        public string Email { get; set; }

        protected AuthenticateUserRejected()
        {

        }

        public AuthenticateUserRejected(string email)
        {
            Email = email;
        }
    }
}
