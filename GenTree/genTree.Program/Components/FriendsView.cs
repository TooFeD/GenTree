using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Controller;
using GenTree.Server.Models;
using Newtonsoft.Json;

namespace GenTree.Program.Forms
{
    public partial class FriendsView : UserControl
    {
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                SetFirstName();
            }
        }

        public string UserId
        {
            get { return _userId; }
            set
            {
                _userId = value;
                SetUserId();
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                SetSecondName();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                SetLastName();
            }
        }

        public DateTime DateOfBirthd
        {
            get { return _dateBirthd; }
            set
            {
                _dateBirthd = value;
                SetDateBirthd();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                SetEmail();
            }
        }

        public Image Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                SetPhoto();
            }
        }

        public bool CanSeeTree
        {
            get { return _canSeeTree; }
            set
            {
                _canSeeTree = value;
                SetCanSeeTree();
            }
        }
   
     

        private string _userId;
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _email;
        private bool _canSeeTree;
        private DateTime _dateBirthd;
        private Image _photo;
        private List<AllMembersViewModel> _members;

        private void SetCanSeeTree()
        {
            button1.Text = CanSeeTree ? "Заборонити перегляд дерева" : "Дозволити перегляд дерева";
        }

        private void SetSecondName()
        {
            label1.Text = "По батькові: " + SecondName;
        }
        private void SetUserId()
        {
            groupBox.Text = "№: " + UserId;
            try
            {
                _members =
                    JsonConvert.DeserializeObject<List<AllMembersViewModel>>(
                        RequestController.HttpGet(
                            MainForm.ServerUrl + "/api/Friendship/GetFriendTree?friendId=" + UserId,
                            MainForm.Token).Result);
            }
            catch (Exception e)
            {
                _members = null;
            }
            if (_members != null)
             if (_members.Count > 0)
                {
                    button2.Enabled = true;
                    return;
                }     
                    button2.Enabled = false;
            
        }

         private void SetFirstName()
        {
            firstNameLabel.Text = "Ім'я: " + FirstName;
        }
        private void SetLastName()
        {
            secondNameLabel.Text = "Прізвище: " + LastName;
        }

        private void SetDateBirthd()
        {
            label2.Text = "День народження: " + DateOfBirthd.Date;
        }

        private void SetEmail()
        {
            label3.Text = "Email: "+Email;
        }

        private void SetPhoto()
        {
            PhotoBox.Image = Photo;
        }
        public FriendsView()
        {
          
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
           RequestController.HttpPOST(MainForm.ServerUrl + "/api/Friendship/ChangeAllowSeeTree?friendId="+UserId+"&canSeeTree=" + !CanSeeTree,
                MainForm.Token);
            CanSeeTree = !CanSeeTree;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}