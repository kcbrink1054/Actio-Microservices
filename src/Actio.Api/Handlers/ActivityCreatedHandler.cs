using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Api.Models;
using Actio.Api.Repositories;
using Actio.Common.Events;

namespace Actio.Api.Handlers
{
    public class ActivityCreatedHandler: IEventHandler<ActivityCreated>
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityCreatedHandler(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public async Task HandleAsync(ActivityCreated model)
        {
            await _activityRepository.AddAsync(new Activity
                {
                    Id = model.Id,
                    Category = model.Category,
                    CreatedAt = model.CreatedAt,
                    Description = model.Description,
                    Name = model.Name,
                    UserId = model.UserId
                });
            Console.WriteLine($"Activity created: {model.Name}");
        }
    }
}
