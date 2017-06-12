using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class UserRepository:BaseRepository<ApplicationUser>
    {
        public UserRepository(DbContext dataContext) : base(dataContext)
        {
        }
       


    }
}