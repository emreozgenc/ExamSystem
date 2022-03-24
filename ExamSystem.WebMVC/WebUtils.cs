using Microsoft.AspNetCore.Mvc.ModelBinding;

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
    }
}
