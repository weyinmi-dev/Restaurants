using FluentValidation;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantPartiallyValidator : AbstractValidator<UpdateRestaurantPartiallyCommand>
{
    public UpdateRestaurantPartiallyValidator()
    {
        RuleFor(dto => dto.Name)
            .Length(3, 100); 
    }
}
