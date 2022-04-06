﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Events
{
    public class CreateActivityRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }


        protected CreateActivityRejected()
        {

        }

        public CreateActivityRejected(Guid id, string code, string reason)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
