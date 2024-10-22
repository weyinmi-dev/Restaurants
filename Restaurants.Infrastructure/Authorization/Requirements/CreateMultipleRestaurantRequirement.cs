﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Infrastructure.Authorization.Requirements
{
    public class CreateMultipleRestaurantRequirement(int minimumRestaurantsCreated) : IAuthorizationRequirement
    {
        public int MinimumRestaurantsCreated { get; } = minimumRestaurantsCreated;
    }
}
