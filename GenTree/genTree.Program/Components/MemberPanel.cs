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

        private string _firstName = "Name";
        private string _secondName = "SecondName";
     
        private Image _photo = global::GenTree.Program.Properties.Resources.Hearthstone_Screenshot_05_01_17_22_08_36;


        public MemberPanel()
        {
            InitializeComponent();
            SetFirstName();
            SetSecondName();
            SetPhoto();
            SetNameGroupBox();
        }

        public void SetSecondName()
        {
            secondNameLabel.Text = Resources.SecondNameLabel+SecondName;
        }

        public void SetNameGroupBox()
        {
            groupBox.Text = FirstName + " " + SecondName;
        }
        public void SetFirstName()
        {
            firstNameLabel.Text = Resources.LabelName+FirstName;
        }

        public void SetPhoto()
        {
            PhotoBox.Image = Photo;
        }
    }
}