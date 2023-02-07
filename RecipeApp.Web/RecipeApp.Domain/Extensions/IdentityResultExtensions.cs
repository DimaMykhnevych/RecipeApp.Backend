﻿using Microsoft.AspNetCore.Identity;
using RecipeApp.Domain.Exceptions;

namespace RecipeApp.Domain.Extensions
{
    public static class IdentityResultExtensions
    {
        public static void ValidateIdentityResult(this IdentityResult identityResult)
        {
            if (!identityResult.Succeeded)
            {
                string errorsMessage = identityResult.Errors
                                         .Select(er => er.Description)
                                         .Aggregate((i, j) => i + ";" + j);
                throw new IdentityResultException(errorsMessage);
            }
        }
    }
}
