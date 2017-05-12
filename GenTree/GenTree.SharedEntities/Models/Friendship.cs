namespace GenTree.SharedEntities.Models
{
    public class Friendship
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string FriendId { get; set; }
        public virtual ApplicationUser Friend { get; set; }
        public bool CanSeeTree { get; set; }
        public bool Accepted { get; set;   }
    }
}