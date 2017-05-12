using System.Web.Http;

namespace GenTree.Server.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
  
    public class UserController:ApiController
    {
        
    }
}