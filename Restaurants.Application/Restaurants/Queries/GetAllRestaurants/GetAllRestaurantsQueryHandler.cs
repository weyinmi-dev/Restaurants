﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Constants;
using Restaurants.Application.Commons;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryHandler(IRestaurantsRepository restaurantsRepository, ILogger<GetAllRestaurantsQueryHandler> logger, IMapper mapper) : IRequestHandler<GetAllRestaurantsQuery, PagedResult<RestaurantDto>>
{
    public async Task<PagedResult<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all restaurants");

        var (restaurants, totalCount) = await restaurantsRepository.GetAllMatchingAsync(request.searchPhrase,
            request.PageSize,
            request.PageNumber,
            request.SortBy,
            request.SortDirection);

        var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        var result = new PagedResult<RestaurantDto>(restaurantDtos, totalCount, request.PageSize, request.PageNumber);

        return result;
    }
}
