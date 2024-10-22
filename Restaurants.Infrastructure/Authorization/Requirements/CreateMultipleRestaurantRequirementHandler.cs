using Microsoft.AspNetCore.Authorization;
using Restaurants.Application.Users;
using Restaurants.Application.Users.UserContext;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Authorization.Requirements
{
    public class CreateMultipleRestaurantRequirementHandler(IRestaurantsRepository restaurantsRepository, IUserContext userContext) : AuthorizationHandler<CreateMultipleRestaurantRequirement>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, CreateMultipleRestaurantRequirement requirement)
        {
            var currentUser = userContext.GetCurrentUser();

            var restaurants = await restaurantsRepository.GetAllAsync();

            var userRestaurantsCreated = restaurants.Count(r => r.OwnerId == currentUser!.Id);

            if(userRestaurantsCreated > requirement.MinimumRestaurantsCreated)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}
