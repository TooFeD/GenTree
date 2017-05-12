using System.Data.Entity;
using System.Linq;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class HaveDiseaseRepository:BaseRepository<HaveDiseases>
    {
        public HaveDiseaseRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public HaveDiseases GetDiseaseByIdMember(int memberId, int diseaseId)
        {
            return DataContext.Set<HaveDiseases>()
                .FirstOrDefault(x => x.MemberId == memberId && x.GenDiseasesId == diseaseId);
        }
    }
}