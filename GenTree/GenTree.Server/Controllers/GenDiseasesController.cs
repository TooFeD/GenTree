using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using GenTree.BLL.Services;
using GenTree.DAL;
using GenTree.DAL.Data;
using GenTree.Server.Models;
using GenTree.SharedEntities.Models;

namespace GenTree.Server.Controllers
{
    [Authorize]
    [RoutePrefix("api/GenDisease")]
    public class GenDiseasesController : ApiController
    {
        [Route("AddDisease")]
        public async Task<IHttpActionResult> AddGenDisease(AddGenDiseasesBindingModel model)
        {
           
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            GenDiseaseService service = new GenDiseaseService(uow);
            var diseases = new GenDiseases()
            {
                Name = model.Name,
                About = model.About,
                MenInherited = model.MenInherited,
                WomenInherited = model.WomenInherited
            };
            service.AddNewDisease(diseases);
            uow.Commit();
            return Ok();
        }

        [Route("GetAllDiseases")]
        public async Task<IHttpActionResult> GetAllDiseases()
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            GenDiseaseService service = new GenDiseaseService(uow);

            List<GenDiseases> allDiseases = service.GetAllGenDiseaseses();

            return await  Task.FromResult(Ok(allDiseases));

        }

        [Route("GetDiseaseById")]
        public async Task<IHttpActionResult> GetDiseaseById(int diseaseId)
        {
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            GenDiseaseService service = new GenDiseaseService(uow);
            GenDiseases disease = service.GetGenDiseasesById(diseaseId);
            return await Task.FromResult(Ok(disease));
        }

        [Route("ChangeDisease")]
        public async Task<IHttpActionResult> ChangeDisease(GenDiseases model)
        {        
            UnitOfWork uow = new UnitOfWork(new ApplicationDbContext());
            GenDiseaseService service = new GenDiseaseService(uow);
            service.CheangeDisease(model);
            uow.Commit();
            return Ok();
        }
    }
}