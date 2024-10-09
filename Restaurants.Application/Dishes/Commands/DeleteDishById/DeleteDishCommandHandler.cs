using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Commands.DeleteDish
{
    public class DeleteDishCommandHandler(ILogger<DeleteDishCommandHandler> logger, IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository) : IRequestHandler<DeleteDishCommand>
    {
        public async Task Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Deleting dish with id {Dish} from Restaurant {Restaurant}", request.RestaurantId, request.DishId);

            var restaurant = await restaurantsRepository.GetById(request.RestaurantId);
            if (restaurant is null)
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
            
            var dishToDelete = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dishToDelete is null)
                throw new NotFoundException(nameof(Dish), request.DishId.ToString());

            await dishesRepository.Delete(dishToDelete);
        }
    }
}
