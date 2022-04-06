using System;
using System.Threading.Tasks;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Services;
using RawRabbit;

namespace Actio.Services.Activities.Handlers
{
    public class CreateActivityHandler: ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;
        private readonly IActivityService _activityService;
        
        public CreateActivityHandler(IBusClient busClient, IActivityService activityService)
        {
            _busClient = busClient;
            _activityService = activityService;
        }
        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating activity: {command.Name}");
            try
            {
                await _activityService.AddAsync(command.Id, command.UserId, command.Category,
                    command.Name, command.Description, command.CreatedAt);
                await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category,
                    command.Name, command.Description, command.CreatedAt));
                return;
            }
            catch (ActioException e)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, e.Code, e.Message));
            }
            catch (Exception e)
            {
                await _busClient.PublishAsync(new CreateActivityRejected(command.Id, "error", e.Message));
            }
        }
    }
}
