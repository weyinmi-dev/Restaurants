using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class RestaurantsRepository(RestaurantsDbContext dbContext) 
    : IRestaurantsRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllAsync()
    {
        var restaurants = await dbContext.Restaurants.ToListAsync();
        return restaurants;
    }

    public async Task<Restaurant?> GetById(int id)
    {
        var restaurant = await dbContext.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        return restaurant;
    }

    public async Task<int> Create(Restaurant entity)
    {
        dbContext.Restaurants.Add(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task Delete(Restaurant entity)
    {
        dbContext.Restaurants.Remove(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task Update(Restaurant entity)
    {
       dbContext.Restaurants.Update(entity);
        await dbContext.SaveChangesAsync();
    }

    public Task SaveChanges()
     => dbContext.SaveChangesAsync();

}
