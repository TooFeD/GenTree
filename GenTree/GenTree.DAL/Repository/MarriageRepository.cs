using System.Data.Entity;
using System.Linq;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class MarriageRepository:BaseRepository<Marriage>
    {
        public MarriageRepository(DbContext dataContext) : base(dataContext)
        {
        }
        public Marriage GetMarriageById(int memb1, int memb2)
        {
            return DataContext.Set<Marriage>()
                .FirstOrDefault(x => x.MemberId == memb1 && x.MarriagId == memb2);
        }
    }
}