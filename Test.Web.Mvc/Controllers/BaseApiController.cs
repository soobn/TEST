
using BF.Data.Mapping;
using Microsoft.AspNetCore.Mvc;

namespace Test.Web.Mvc.Controllers
{
    public class BaseApiController:ControllerBase
    {
        public IObjectMapper ObjectMapper { get; }
    }
}