using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Security.Claims;

namespace ExamSystem.WebMVC
{
    public static class WebUtils
    {
        public static void AddErrorsFromModel(ModelStateDictionary modelStateDictionary)
        {
            var values = modelStateDictionary.Values;
            foreach (ModelStateEntry modelState in values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    modelStateDictionary.AddModelError(string.Empty, error.ErrorMessage.ToString());
                }
            }
        }

        public static int GetUserIdFromClaims(ClaimsPrincipal user)
        {
            var userId = Convert.ToInt32(user.FindFirst(ClaimTypes.NameIdentifier).Value);
            return userId;
        }
    }
}
