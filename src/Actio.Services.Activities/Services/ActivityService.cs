using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Actio.Common.Exceptions;
using Actio.Services.Activities.Domain.Modals;
using Actio.Services.Activities.Domain.Repositories;
using Microsoft.AspNetCore.Server.IIS.Core;

namespace Actio.Services.Activities.Services
{
    public class ActivityService: IActivityService
    {
        private readonly IActivityRepository _activityRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ActivityService(IActivityRepository activityRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _activityRepository = activityRepository;
        }
        public async Task AddAsync(Guid id, Guid userId, string category, string name, string description, DateTime createdAt)
        {
            var activitycategory = await _categoryRepository.GetAsync(name);
            if (activitycategory == null)
            {
                throw new ActioException("category not found", $"Category:{category} was not found.");
            }

            await _activityRepository.AddAsync(new Activity(id, activitycategory, userId, name, description, createdAt));
        }
    }
}
