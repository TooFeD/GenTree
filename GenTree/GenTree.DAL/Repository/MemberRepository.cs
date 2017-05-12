using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class MemberRepository:BaseRepository<Member>
    {
        public MemberRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public List<Member> GetMembersByUserId(string userId)
        {
            return DataContext.Set<Member>()
                .Where(x => x.Tree.ApplicationUserId == userId).ToList();
        }

        

       
    }
}