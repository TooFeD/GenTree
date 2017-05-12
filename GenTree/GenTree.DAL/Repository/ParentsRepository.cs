using System.Data.Entity;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class ParentsRepository:BaseRepository<Parents>
    {
        public ParentsRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}