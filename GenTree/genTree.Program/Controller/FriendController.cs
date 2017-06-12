using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Forms;
using GenTree.Server.Models.FriendshipsModel;
using Newtonsoft.Json;

namespace GenTree.Program.Controller
{
    public class FriendController
    {
        private FlowLayoutPanel _panel;
        public FriendController(FlowLayoutPanel panel)
        {
            _panel = panel;
        }

        public void ShowAllUser()
        {
            _panel.Controls.Clear();
            List<FollowerViewModel> usersList =
                JsonConvert.DeserializeObject<List<FollowerViewModel>>(
                    RequestController.HttpGet(MainForm.ServerUrl + "/api/User/GetAllUser", MainForm.Token).Result);
            foreach (var ul in usersList)
            {
               
                MemberPanel memberPanel = new MemberPanel();
                memberPanel.FirstName = ul.FirstName;
                memberPanel.SecondName = ul.LastName;
                memberPanel.Photo = byteArrayToImage(ul.Photo);
                _panel.Controls.Add(memberPanel);
            }
        }

        public void ShowUserByName(string name)
        {
            _panel.Controls.Clear();
            List<FollowerViewModel> usersList =
                JsonConvert.DeserializeObject<List<FollowerViewModel>>(
                    RequestController.HttpGet(MainForm.ServerUrl + "/api/User/GetUserByName?name="+name, MainForm.Token).Result);
            foreach (var ul in usersList)
            {

                MemberPanel memberPanel = new MemberPanel();
                memberPanel.FirstName = ul.FirstName;
                memberPanel.SecondName = ul.LastName;
                memberPanel.Photo = byteArrayToImage(ul.Photo);
                _panel.Controls.Add(memberPanel);
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
