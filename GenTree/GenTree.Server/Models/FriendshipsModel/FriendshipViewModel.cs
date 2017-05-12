using System;

namespace GenTree.Server.Models.FriendshipsModel
{
    public class FollowerViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }

    }

    public class FriendsViewModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }
        public bool CanSeeTree { get; set; }
        public bool Accepted { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int TreeId { get; set; }
    }
}