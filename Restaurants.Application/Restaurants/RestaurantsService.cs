using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Dtos;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using System.ComponentModel.DataAnnotations;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService : IRestaurantsService
{
    private readonly IRestaurantsRepository _restaurantsRepository;
    private readonly ILogger<RestaurantsService> _logger;
    private readonly IMapper _mapper;

    public RestaurantsService(IRestaurantsRepository restaurantsRepository, ILogger<RestaurantsService> logger, IMapper mapper)
    {
        _restaurantsRepository = restaurantsRepository;
        _logger = logger;
        _mapper = mapper;
    }

    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        _logger.LogInformation("Getting all restaurants");
        var restaurants = await _restaurantsRepository.GetAllAsync();
        var restaurantDtos = _mapper.Map<IEnumerable<RestaurantDto>>(restaurants); 
        
        return restaurantDtos;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        _logger.LogInformation($"Getting restaurant by {id}");
        var restaurant = await _restaurantsRepository.GetById(id);
        var restaurantDto = _mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }

    public async Task<int> Create(CreateRestaurantDto createRestaurantDto)
    {
        _logger.LogInformation("Creating a new restaurant");
        var restaurant = _mapper.Map<Restaurant>(createRestaurantDto);

        int id = await _restaurantsRepository.Create(restaurant);
        return id;
    }
}
