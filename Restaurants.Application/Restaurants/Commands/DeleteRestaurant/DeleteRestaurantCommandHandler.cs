using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(IRestaurantsRepository restaurantsRepository, ILogger<DeleteRestaurantCommandHandler> logger) : IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting requests with id {RestaurantId}", request.Id);
        var restaurant = await restaurantsRepository.GetById( request.Id );

        if ( restaurant == null ) 
        {
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        }

        await restaurantsRepository.Delete(restaurant);
    }
}
