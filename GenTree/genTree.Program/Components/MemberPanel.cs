using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Properties;
using GenTree.Server.Models;
using GenTree.SharedEntities.Models;

namespace GenTree.Program.Forms
{
    public partial class MemberPanel : UserControl
    {
        public Image Photo
        {
            get { return _photo;}
            set { _photo = value; SetPhoto(); }
        }
   
        public String FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                SetFirstName();
                SetNameGroupBox();
            }
        }

        public String SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                SetSecondName();
                SetNameGroupBox();
            }
        }

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                SetLastName();
                SetNameGroupBox();
            }
        }

        public string Sex
        {
            get { return _sex; }
            set
            {
                _sex = value;
                SetSex();
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth =value;
                SetDateOfBirth();
            }
        }

        public DateTime DateOfDeth
        {
            get { return _dateOfDeth; }
            set
            {
                _dateOfDeth = value;
                SetDateOfDethth();
            }
        }

        public string Addres
        {
            get { return _address; }
            set
            {
                _address = value;
                SetAddres();
            }
        }

        public string OtherInfo
        {
            get { return _otherInfo; }
            set
            {
                _otherInfo = value;
                SetOtherInfo();
            }
        }

        public int Id { get; set; }
        public List<ParentsViewModel> Parents { get; set; }
        public List<ChildsViewModel> Childs { get; set; }
        public List<MarriageViewModel> Marriages { get; set; }
        public List<HaveDiseaseViewModel> Diseaseses { get; set; }
        private string _firstName;
        private string _secondName;
        private string _lastName;
        private string _sex;
        private DateTime _dateOfBirth;
        private DateTime _dateOfDeth;
        private string _address;
        private string _otherInfo;
     
        private Image _photo = global::GenTree.Program.Properties.Resources.Hearthstone_Screenshot_05_01_17_22_08_36;

       
        public  MemberPanel()
        {
            InitializeComponent();
            //SetFirstName();
            //SetSecondName();
            //SetPhoto();
            //SetNameGroupBox();
        }

        public void SetOtherInfo()
        {
            textBox1.Text = OtherInfo;
        }
        public void SetAddres()
        {
            label5.Text = "Адреса: " + Addres;
        }
        public void SetDateOfDethth()
        {
            label4.Text = "Дата смерті: " + DateOfDeth.Date;
        }
        public void SetDateOfBirth()
        {
            label3.Text = "Дата народження: " + DateOfBirth.Date;
        }
        public void SetSex()
        {
            label2.Text = "Стать: " + Sex;
        }
        public void SetLastName()
        {
            secondNameLabel.Text = Resources.SecondNameLabel + LastName;
        }
        public void SetSecondName()
        {
            label1.Text = "По батькові: "+SecondName;
        }

        public void SetNameGroupBox()
        {
            groupBox.Text = FirstName + " " + LastName;
        }
        public void SetFirstName()
        {
            firstNameLabel.Text = Resources.LabelName+FirstName;
        }

        public void SetPhoto()
        {
            PhotoBox.Image = Photo;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //361 181
            //361 299
            if (button3.Text == "Розгорнути")
            {
                Size = new Size(361, 299);
                button3.Text = "Згорнути";
            }
            else
            {
                Size = new Size(361, 181);
                button3.Text = "Розгорнути";
            }
        }
        }
    }
