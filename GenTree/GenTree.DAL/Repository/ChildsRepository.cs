using System.Data.Entity;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class ChildsRepository:BaseRepository<Childs>
    {
        public ChildsRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}