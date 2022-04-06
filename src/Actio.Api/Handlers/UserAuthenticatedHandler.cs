using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class UserAuthenticatedHandler : IEventHandler<UserAuthenticated>
    {
        public Task HandleAsync(UserAuthenticated @event)
        {
            throw new NotImplementedException();
        }
    }
}
