﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Actio.Common.Commands
{
    public class AuthenticateUser: ICommand
    {
        public string Email { get; set; }
        public string Password { get; set; }


    }
}
