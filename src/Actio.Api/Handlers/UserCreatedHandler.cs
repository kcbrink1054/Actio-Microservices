﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class UserCreatedHandler: IEventHandler<UserCreated>
    {
        public Task HandleAsync(UserCreated @event)
        {
            throw new NotImplementedException();
        }
    }
}
