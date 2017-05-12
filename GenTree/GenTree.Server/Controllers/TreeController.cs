using System.Web.Http;

namespace GenTree.Server.Controllers
{
    [Authorize]
    [RoutePrefix("api/Tree")]
    public class TreeController:ApiController
    {
        
    }
}