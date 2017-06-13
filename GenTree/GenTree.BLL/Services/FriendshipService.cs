using System;
using System.Collections.Generic;
using System.Linq;
using GenTree.DAL;
using GenTree.DAL.Data;
using GenTree.SharedEntities.Models;

namespace GenTree.BLL.Services
{
    public class FriendshipService:ServiceBase
    {
        public FriendshipService(UnitOfWork uow) : base(uow)
        {
        }

        public void AddUserToFriend(string userId,string friendId)
        {
           Friendship friend = new Friendship()
           {
               Accepted = false,
               CanSeeTree = false,
               UserId = userId,
               FriendId = friendId            
           };
            Uow.FriendshipRepository.Add(friend);
        }

        public List<ApplicationUser> GetAllFolowers(string userId)
        {
           return Uow.FriendshipRepository.GetAllFolowers(userId);
        }

        public List<ApplicationUser> GetAllUsers(string userId)
        { var context = new ApplicationDbContext();
            var allUser = context.Users.Where(x=>x.Id!=userId).ToList();
            return allUser;
        }
        public List<ApplicationUser> GetUserByName(string name, string userId)
        {
            var context = new ApplicationDbContext();
            var allUser = context.Users.Where(x=>x.FirstName.Contains(name)|| x.LastName.Contains(name)&&x.Id!=userId).ToList();
            return allUser;
        }


        public void AcceptedFriends(string userId,string followerId)
        {
            var friendToAccepted = Uow.FriendshipRepository.GetFollower(userId, followerId);
            friendToAccepted.Accepted = true;
            Friendship newFriend = new Friendship()
            {
                UserId = userId,
                Accepted = true,
                CanSeeTree   = false,
                FriendId = followerId
            };
            Uow.FriendshipRepository.Add(newFriend);
        }
        public void ChangeAllowSeeTree(string userId, string friendId,bool canSeeTree)
        {
            var friendCanSeeTree = Uow.FriendshipRepository.AllowSeeTreeById(userId, friendId);
            friendCanSeeTree.CanSeeTree = canSeeTree;
           
        }

        public List<Friendship> GetAllFriendByUser(string userId)
        {
           return Uow.FriendshipRepository.GetFriendships(userId);
        }

        public List<Member> GetAllMembersInTreeFriend(string userId, string friendId)
        {
            var friend = Uow.FriendshipRepository.GetFriendship(userId, friendId);
            if (friend.CanSeeTree)
            {
                return Uow.MemberRepository.GetMembersByUserId(friendId);
            }

            return null;
        }
       
    }
}