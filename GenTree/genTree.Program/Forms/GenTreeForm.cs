using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }
}
