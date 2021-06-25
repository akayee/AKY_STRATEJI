using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ABB.WebMvcUI.Models
{
    public class ABBErrorJsonResponse: BadRequestObjectResult
    {
        public ABBErrorJsonResponse(string error) : base(new {mesaj = error})
        {
        }

        public ABBErrorJsonResponse(object error) : base(error)
        {
        }

        public ABBErrorJsonResponse(ModelStateDictionary modelState) : base(modelState)
        {
        }
    }
}