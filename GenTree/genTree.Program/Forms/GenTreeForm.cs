using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Controller;
using GenTree.Server.Models;
using Newtonsoft.Json;

namespace GenTree.Program.Forms
{
    public partial class GenTreeForm : Form
    {
        private string _userInfoUrl = "/api/Account/UserInfo";
        public Acces Token;
        public UserInfoViewModel UserInfo;
        public FriendController FriendController;

        public GenTreeForm(Acces token)
        {
            Token = token;
            _userInfoUrl = MainForm.ServerUrl + _userInfoUrl;
            UserInfo =
                JsonConvert.DeserializeObject<UserInfoViewModel>(RequestController.HttpGet(_userInfoUrl, Token).Result);
            InitializeComponent();
            label1.Text = UserInfo.LastName;
            label2.Text = UserInfo.FirstName;
            label3.Text = UserInfo.SecondName;
            pictureBox1.Image = byteArrayToImage(UserInfo.Photo);
          
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
            return null;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(tabPage1);
            GenerateTree(panel1,MainForm.ServerUrl+ "/api/Member/GetAllMembers");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FriendController = new FriendController(flowLayoutPanel1);
            button5.Text = "Підписники "+FriendController.GetCountFollowers();
            button6.Text = "Друзі " + FriendController.GetCountFriends();
            tabControl1.SelectTab(tabPage2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            FriendController.ShowAllUser();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                FriendController.ShowUserByName(textBox1.Text);
            else FriendController.ShowAllUser();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FriendController.ShowAllFolowers();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FriendController.ShowAllFriends();
        }

        private void memberPanel1_Load(object sender, EventArgs e)
        {
            
        }

        public void GenerateTree(Panel panel,string urlApi)
        {
            List<AllMembersViewModel> members =
                JsonConvert.DeserializeObject<List<AllMembersViewModel>>(
                    RequestController.HttpGet(urlApi, MainForm.Token).Result);
            List<AllMembersViewModel> childs = members.Where(x => x.Childs.Count == 0).ToList();
            foreach (var child in childs)
            {
                RequrseGenerate(child,members,panel,500,3);
            }
        }

        public void RequrseGenerate(AllMembersViewModel child, List<AllMembersViewModel> members, Panel panel ,int posx, int level)
        {
            MemberPanel memberPanel = new MemberPanel()
            {
                FirstName = child.FirstName,
                SecondName = child.SecondName,
                LastName = child.LastName,
                Sex = child.Sex,
                DateOfBirth = child.DateOfBirth,
                DateOfDeth = child.DateOfDeth,
                Addres = child.Address,
                OtherInfo = child.OtherInfo,
                Id = child.Id,
                Photo = byteArrayToImage(child.Photo),
                Parents = child.Parents,
                Childs = child.Childs,
                Diseaseses = child.Diseaseses,
                Marriages = child.Marriages,
                Location = new Point(posx,level)
            };
            panel.Controls.Add(memberPanel);
            if(child.Parents.Count>0)
                RequrseGenerate(members.FirstOrDefault(x=>x.Id == child.Parents[0].ParentId),members,panel ,posx-300,level+205);
            if (child.Parents.Count > 1)
                RequrseGenerate(members.FirstOrDefault(x => x.Id == child.Parents[1].ParentId), members,panel,posx+300,level +205);

        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
           

        }
    }
}