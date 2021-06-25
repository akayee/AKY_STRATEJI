using Microsoft.AspNetCore.Mvc;

namespace ABB.WebMvcUI.Models
{
    public class ABBJsonResponse: JsonResult
    {

        public ABBJsonResponse(string mesaj) : base(new {mesaj = mesaj})
        {
        }

        public ABBJsonResponse(ABBJsonResponse value) : base(value)
        {
        }

        public ABBJsonResponse(ABBJsonResponse value, object serializerSettings) : base(value, serializerSettings)
        {
        }
    }
}