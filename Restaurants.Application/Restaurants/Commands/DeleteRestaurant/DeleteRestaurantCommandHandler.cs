using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand, bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting requests with id {RestaurantId}", request.Id);
        var restaurant = await restaurantsRepository.GetById( request.Id );

        if ( restaurant == null )
        {
            return false;
        }

        await restaurantsRepository.Delete(restaurant);
        return true;
    }
}
