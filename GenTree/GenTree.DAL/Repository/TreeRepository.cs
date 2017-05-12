using System.Data.Entity;
using System.Linq;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class TreeRepository: BaseRepository<Tree>
    {
        public TreeRepository(DbContext dataContext) : base(dataContext)
        {
            
        }

        public Tree GetByUserId(string userId)
        {
            return DataContext.Set<Tree>()
                .FirstOrDefault(x => x.ApplicationUserId == userId);
        }
    }
}