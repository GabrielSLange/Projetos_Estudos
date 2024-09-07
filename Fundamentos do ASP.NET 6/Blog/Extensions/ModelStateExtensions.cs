using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Blog.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrors(this ModelStateDictionary modelState)
        {
            var result = new List<string>();
            foreach(var entity in modelState.Values)
            {
                foreach(var error in entity.Errors)
                {
                    result.Add(error.ErrorMessage);
                }
            }
            return result;

        }
    }
}
