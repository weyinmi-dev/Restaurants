﻿using MediatR;
using Restaurants.Application.Commons;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Constants;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<PagedResult<RestaurantDto>>
{
    public string? searchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
}
