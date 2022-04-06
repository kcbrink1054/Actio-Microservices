using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Identity.Domain.Repositories;
using Actio.Services.Identity.Services;
using RawRabbit;

namespace Actio.Services.Identity.Handlers
{
    public class CreateUserHandler: ICommandHandler<CreateUser>
    {
        private readonly IBusClient _busClient;
        private readonly IUserService _userService;

        public CreateUserHandler(IBusClient busClient, IUserService userService)
        {
            _busClient = busClient;
            _userService = userService;
        }

        public async Task HandleAsync(CreateUser command)
        {
            Console.WriteLine($"Create User: {command.Email} {command.Name}");
            try
            {
                await _userService.RegisterAsync(command.Email, command.Password,command.Name);
                await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));
                return;
            }
            catch (ActioException e)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, e.Code, e.Message));
            }
            catch (Exception e)
            {
                await _busClient.PublishAsync(new CreateUserRejected(command.Email, "error", e.Message));
            }
            await _busClient.PublishAsync(new UserCreated(command.Email, command.Name));

        }
    }
}
