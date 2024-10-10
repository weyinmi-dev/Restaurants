namespace Restaurants.Application.Users.UserContext.UserContext
{
    public interface IUserContext
    {
        CurrentUser? GetCurrentUser();
    }
}