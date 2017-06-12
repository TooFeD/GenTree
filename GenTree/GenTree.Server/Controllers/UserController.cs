using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GenTree.BLL.Services;
using GenTree.DAL;
using GenTree.DAL.Data;
using GenTree.Server.Models.FriendshipsModel;
using Microsoft.AspNet.Identity;

namespace GenTree.Server.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
  
    public class UserController:ApiController
    {
        [Route("GetAllUser")]
      
        public async Task<IHttpActionResult> GetAllUsers()
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            var users= service.GetAllUsers(userId);

            var folowers = users.Select(x => new FollowerViewModel()
            {
                UserId = x.Id,
                Photo = x.Photo,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName
            }).ToList();


            return await Task.FromResult(Ok(folowers));
        }
        [Route("GetUserByName")]

        public async Task<IHttpActionResult> GetUserByName(string name)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
          
            var users = service.GetUserByName(name);

            var folowers = users.Select(x => new FollowerViewModel()
            {
                UserId = x.Id,
                Photo = x.Photo,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName
            }).ToList();


            return await Task.FromResult(Ok(folowers));
        }
    }
}