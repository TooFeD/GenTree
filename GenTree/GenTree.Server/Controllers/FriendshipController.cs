using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Http;
using System.Web.Http.Results;
using GenTree.BLL.Services;
using GenTree.DAL;
using GenTree.DAL.Data;
using GenTree.Server.Models;
using GenTree.Server.Models.FriendshipsModel;
using GenTree.SharedEntities.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GenTree.Server.Controllers
{
    [Authorize]
    [RoutePrefix("api/Friendship")]
    public class FriendshipController : ApiController
    {
        [Route("AddUserToFriend")]
        public async Task<IHttpActionResult> AddUserToFriend(string friendId)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            service.AddUserToFriend(userId, friendId);
            uow.Commit();
            return Ok();
        }


        [Route("GetFolowers")]
        [Description("getAllUserFolowers")]  
        public async Task<IHttpActionResult> GetAllFolowers()
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            var followersForAccepted = service.GetAllFolowers(userId);

            var folowers = followersForAccepted.Select(x => new FollowerViewModel()
            {
                UserId = x.Id,
                Photo = x.Photo,
                FirstName = x.FirstName,
                LastName = x.LastName,
                SecondName = x.SecondName
            }).ToList();


            return await Task.FromResult(Ok(folowers));
        }

        [Route("AcceptedFriend")]
        public async Task<IHttpActionResult> AcceptedFollowersToFriend(string followerId)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            service.AcceptedFriends(userId, followerId);
            uow.Commit();
            return Ok();
        }

        [Route("ChangeAllowSeeTree")]
        public async Task<IHttpActionResult> ChangeAllowSeeTree(string friendId, bool canSeeTree)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            service.ChangeAllowSeeTree(userId, friendId, canSeeTree);
            uow.Commit();
            return Ok();
        }

        [Route("GetFriends")]
        public async Task<IHttpActionResult> GetAllFriends()
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            var friendships =service.GetAllFriendByUser(userId);
            var friends = friendships.Select(x => new FriendsViewModel()
            {
                UserId = x.UserId,
                Accepted = x.Accepted,
                CanSeeTree = x.CanSeeTree,
                Photo = x.User.Photo,
                FirstName = x.User.FirstName,
                LastName = x.User.LastName,
                SecondName = x.User.SecondName,
                DateOfBirth = x.User.DateOfBith,
             
            });
            return await Task.FromResult(Ok(friends));
        }

        [Route("GetFriendTree")]
        public async Task<IHttpActionResult> GetUserTree(string friendId)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            FriendshipService service = new FriendshipService(uow);
            var userId = User.Identity.GetUserId();
            var membersList = service.GetAllMembersInTreeFriend(userId, friendId);
            if (membersList != null)
            {
                var members = membersList.Select(x => new AllMembersViewModel()
                {
                    Parents = x.Childs.Select(p => new ParentsViewModel()
                    {
                        ParentId = p.MemberId
                    }).ToList(),
                    Photo = x.Photo,
                    Childs = x.Parents.Select(c => new ChildsViewModel()
                    {
                        ChieldId = c.MemberId
                    }).ToList(),
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SecondName = x.SecondName,
                    Marriages = x.Marriages.Select(m => new MarriageViewModel()
                    {
                        MarriageId = m.MemberId,
                        IsMarriade = m.IsMarriade

                    }).ToList(),
                    Diseaseses = x.Diseaseses.Select(d => new HaveDiseaseViewModel()
                    {
                        DiseaseId = d.GenDiseasesId,
                        About = d.GenDiseases.About,
                        MenInherited = d.GenDiseases.MenInherited,
                        WomenInherited = d.GenDiseases.WomenInherited,
                        Dominante = d.Dominant,
                        NameDisease = d.GenDiseases.Name

                    }).ToList(),
                    DateOfBirth = x.DateOfBirth,
                    DateOfDeth = x.DateOfDeth,
                    Sex = x.Sex,
                    OtherInfo = x.OtherInfo,
                    Address = x.Address

                });
                return await Task.FromResult(Ok(members));
            }
            else
                return Ok();
        }
    }
}