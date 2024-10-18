using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Constants;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Interfaces;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantPartiallyCommandHandler(IRestaurantsRepository restaurantsRepository, ILogger<UpdateRestaurantPartiallyCommandHandler> logger, IMapper mapper, IRestaurantAuthorizationService restaurantAuthorizationService) : IRequestHandler<UpdateRestaurantPartiallyCommand>
{
    public async Task Handle(UpdateRestaurantPartiallyCommand update, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating restaurant with id: {RestaurantId} with {@UpdatedRestaurant}", update.Id, update);
        var restaurant = await restaurantsRepository.GetById(update.Id);
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), update.Id.ToString());

        if (!restaurantAuthorizationService.Authorize(restaurant, ResourceOperation.Update))
            throw new ForbidException();

        mapper.Map(update, restaurant);

        await restaurantsRepository.SaveChanges();
    }
}
