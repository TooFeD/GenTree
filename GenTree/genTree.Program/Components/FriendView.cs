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

namespace GenTree.Program.Forms
{
    public partial class FriendView : UserControl
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
   
     

        private string _userId;
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _email;
        private DateTime _dateBirthd;
        private Image _photo;
     
        private void SetSecondName()
        {
            label1.Text = "По батькові: " + SecondName;
        }
        private void SetUserId()
        {
            groupBox.Text = "№: " + UserId;
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
        public FriendView()
        {
          
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
           RequestController.HttpPOST(MainForm.ServerUrl + "/api/Friendship/AddUserToFriend?friendId=" + UserId,
                MainForm.Token);
            button1.Enabled = false;
        }
        public void button1_Click2(object sender, EventArgs e)
        {
            RequestController.HttpPOST(MainForm.ServerUrl + "/api/Friendship/AcceptedFriend?followerId=" + UserId,
                 MainForm.Token);
            button1.Enabled = false;
        }
        
    }
}