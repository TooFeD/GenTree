using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GenTree.SharedEntities.Models;

namespace GenTree.DAL.Repository
{
    public class FriendshipRepository : BaseRepository<Friendship>
    {
        public FriendshipRepository(DbContext dataContext) : base(dataContext)
        {
        }

        public List<ApplicationUser> GetAllFolowers(string userId)
        {
            List<ApplicationUser> folowers = DataContext.Set<Friendship>()
                .Where(x => x.FriendId == userId && x.Accepted == false).Select(x => x.User).ToList();
            return folowers;
        }

        public Friendship GetFollower(string userId, string followerId)
        {
            return DataContext.Set<Friendship>()
                .FirstOrDefault(x => x.UserId == followerId && x.FriendId == userId && x.Accepted == false);
        }

        public List<Friendship> GetFriendships(string userId)
        {
            return DataContext.Set<Friendship>()
                .Where(x => x.FriendId == userId&&x.Accepted).ToList();
        }

        public Friendship AllowSeeTreeById(string userId, string friendId)
        {
            return DataContext.Set<Friendship>()
                .FirstOrDefault(x => x.UserId == userId&&x.FriendId == friendId);
        }

        public Friendship GetFriendship(string userId, string friendId)
        {
            return DataContext.Set<Friendship>()
                .FirstOrDefault(x => x.FriendId == userId && x.UserId == friendId&&x.Accepted);
        }

        
    }
}