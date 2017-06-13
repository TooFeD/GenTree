using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
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
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
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
    }
}