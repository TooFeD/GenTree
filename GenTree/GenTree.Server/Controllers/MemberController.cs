using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using GenTree.BLL.Services;
using GenTree.DAL;
using GenTree.DAL.Data;
using GenTree.Server.Models;
using GenTree.SharedEntities.Models;
using Microsoft.AspNet.Identity;

namespace GenTree.Server.Controllers
{
    [Authorize]
    [RoutePrefix("api/Member")]
    public class MemberController : ApiController
    {
        [Route("AddMember")]
        public async Task<IHttpActionResult> AddMember(AddMemberBindingModel model)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);

            Member member = new Member()
            {
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                LastName = model.LastName,
                Address = model.Address,
                DateOfBirth = model.DateOfBirth,
                DateOfDeth = model.DateOfDeth,
                Sex = model.Sex,
                Photo = model.Photo,
                OtherInfo = model.OtherInfo
            };
            var userId = User.Identity.GetUserId();
            service.AddMember(userId, member);
            uow.Commit();

            return Ok();
        }

        [Route("AddLinkChildOrParent")]
        public async Task<IHttpActionResult> AddLinkChildParent(int childId, int parentId)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            service.CreateLinkChildParent(childId, parentId);
            uow.Commit();
            return Ok();
        }

        [Route("AddLinkMarriage")]
        public async Task<IHttpActionResult> AddLinkMarriage(int member1Id, int member2Id)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            service.CreateLinkMarriage(member1Id, member2Id);
            uow.Commit();
            return Ok();
        }

        [Route("ChangeMarriade")]
        public async Task<IHttpActionResult> ChangeMarriade(int memb1, int memb2, bool isMarriad)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            service.ChangeMarriade(memb1, memb2, isMarriad);
            uow.Commit();
            return Ok();
        }

        [Route("GetAllMembers")]
        public async Task<IHttpActionResult> GetAllMembers()
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            var userId = User.Identity.GetUserId();
            var membersList = service.GetMemberByUserId(userId);
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

        [Route("ChangeMember")]
        public async Task<IHttpActionResult> ChangeMember(Member member)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            service.ChangeMember(member);
            uow.Commit();
            return Ok();
        }

        [Route("AddDiseaseToMember")]
        public async Task<IHttpActionResult> AddDiseaseToMember(int diseaseId, int memberId)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            service.AddDiseaseToMember(diseaseId,memberId);
            uow.Commit();
            return Ok();
        }

        [Route("ChangeDiseaseMember")]
        public async Task<IHttpActionResult> ChangeDiseaseinMember(HaveDiseaseBindingModel model)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            MemberService service = new MemberService(uow);
            HaveDiseases disease = new HaveDiseases()
            {
                MemberId = model.MemberId,
                Dominant = model.Dominante,
                GenDiseasesId = model.DiseaseId

            };
            service.ChangeDiseaseInMember(model.MemberId, model.CurrentDiseaseId, disease);
            uow.Commit();
            return Ok();
        }

    }
}