using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Forms;
using GenTree.Server.Models;
using GenTree.Server.Models.FriendshipsModel;
using GenTree.SharedEntities.Models;
using Newtonsoft.Json;

namespace GenTree.Program.Controller
{
    public class FriendController
    {
        private FlowLayoutPanel _panel;
        public  List<UsersInfoViewModel> Followers;
        public List<FriendsViewModel> Friends;
        public FriendController(FlowLayoutPanel panel)
        {
            _panel = panel;
          Followers =
              JsonConvert.DeserializeObject<List<UsersInfoViewModel>>(
                  RequestController.HttpGet(MainForm.ServerUrl + "/api/Friendship/GetFolowers", MainForm.Token).Result);
            Friends = JsonConvert.DeserializeObject<List<FriendsViewModel>>(
                  RequestController.HttpGet(MainForm.ServerUrl + "/api/Friendship/GetFriends", MainForm.Token).Result);
        }

        public int GetCountFollowers()
        {
            if (Followers !=null)
            return Followers.Count;
            return 0;
        }

        public int GetCountFriends()
        {
            if (Friends != null)
                return Friends.Count;
            return 0;
        }

        public void ShowAllFolowers()
        {
            _panel.Controls.Clear();
            foreach (var ul in Followers)
            {

                FriendView friend = new FriendView()
                {
                    UserId = ul.UserId,
                    Email = ul.Email,
                    FirstName = ul.FirstName,
                    SecondName = ul.SecondName,
                    LastName = ul.LastName,
                    DateOfBirthd = ul.DateOfBith,
                    Photo = byteArrayToImage(ul.Photo)
                };
                friend.button1.Click -= friend.button1_Click;
                friend.button1.Click += friend.button1_Click2;            
                _panel.Controls.Add(friend);

            }
        }

        public void ShowAllFriends()
        {
            Friends.Clear();
            Friends = JsonConvert.DeserializeObject<List<FriendsViewModel>>(
               RequestController.HttpGet(MainForm.ServerUrl + "/api/Friendship/GetFriends", MainForm.Token).Result);
            _panel.Controls.Clear();
            foreach (var ul in Friends)
            {

                FriendsView friend = new FriendsView()
                {
                    UserId = ul.UserId,
                    Email = ul.Email,
                    FirstName = ul.FirstName,
                    SecondName = ul.SecondName,
                    LastName = ul.LastName,
                    DateOfBirthd = ul.DateOfBirth.Date,
                    Photo = byteArrayToImage(ul.Photo),
                    CanSeeTree = ul.CanSeeTree
                };
             
                _panel.Controls.Add(friend);

            }

        }

        public void ShowAllUser()
        {
            _panel.Controls.Clear();
            List<UsersInfoViewModel> usersList =
                JsonConvert.DeserializeObject<List<UsersInfoViewModel>>(
                    RequestController.HttpGet(MainForm.ServerUrl + "/api/User/GetAllUser", MainForm.Token).Result);
            foreach (var ul in usersList)
            {
               
               FriendView friend = new FriendView()
               {
                  UserId = ul.UserId,
                  FirstName = ul.FirstName,
                  SecondName = ul.SecondName,
                  LastName = ul.LastName,
                  DateOfBirthd = ul.DateOfBith,
                  Photo = byteArrayToImage(ul.Photo),
                  
               };
                if (Friends.FirstOrDefault(x => x.UserId == friend.UserId) != null)
                {
                    friend.button1.Enabled = false;
                }
             
                _panel.Controls.Add(friend);
                
            }
        }

        public void ShowUserByName(string name)
        {
            _panel.Controls.Clear();
            List<UsersInfoViewModel> usersList =
                JsonConvert.DeserializeObject<List<UsersInfoViewModel>>(
                    RequestController.HttpGet(MainForm.ServerUrl + "/api/User/GetUserByName?name="+name, MainForm.Token).Result);
            foreach (var ul in usersList)
            {

                FriendView friend = new FriendView()
                {
                    UserId = ul.UserId,
                    Email = ul.Email,
                    FirstName = ul.FirstName,
                    SecondName = ul.SecondName,
                    LastName = ul.LastName,
                    DateOfBirthd = ul.DateOfBith,
                    Photo = byteArrayToImage(ul.Photo)
                };
                if (Friends.FirstOrDefault(x => x.UserId == friend.UserId) != null)
                {
                    friend.button1.Enabled = false;
                }

                _panel.Controls.Add(friend);
            }
        }
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

      

    }
}
