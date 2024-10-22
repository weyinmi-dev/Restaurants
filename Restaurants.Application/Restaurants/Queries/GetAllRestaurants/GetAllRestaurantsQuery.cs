using MediatR;
using Restaurants.Application.Commons;
using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Restaurants.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<PagedResult<RestaurantDto>>
{
    public string? searchPhrase { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
