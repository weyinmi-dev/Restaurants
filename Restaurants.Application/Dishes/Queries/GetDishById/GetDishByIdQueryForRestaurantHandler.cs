using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Application.Dishes.Queries.GetDishById
{
    public class GetDishByIdQueryForRestaurantHandler(ILogger<GetDishByIdQueryForRestaurantHandler> logger, IRestaurantsRepository restaurantsRepository, IMapper mapper) : IRequestHandler<GetDishByIdQueryForRestaurant, DishDto>
    {
        public async Task<DishDto> Handle(GetDishByIdQueryForRestaurant request, CancellationToken cancellationToken)
        {
           logger.LogInformation("Retrieving dish {@Dish} for Restaurant {RestaurantId}", request.DishId.ToString(), request.RestaurantId.ToString());

            var restaurant = await restaurantsRepository.GetById(request.RestaurantId);
            if (restaurant is null) 
                throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());

            var dish = restaurant.Dishes.FirstOrDefault(d => d.Id == request.DishId);
            if (dish is null)
                throw new NotFoundException(nameof(dish), request.DishId.ToString());

            var result = mapper.Map<DishDto>(dish);

            return result;
        }
    }
}
