namespace GenTree.Server.Models.FriendshipsModel
{
    public class AddFriendBindingModel
    {
        public string UserId { get; set; }
        public string FriendId { get; set; }
        public bool CanSeeTree { get; set; }
        public bool Accepted { get; set; }

    }
}