using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Server.Models;
namespace GenTree.SharedEntities
{
    public partial class MemberAddForms : Form
    {
        public string apiUrl = "/api/Member/AddMember";
        public MemberAddForms()
        {
            InitializeComponent();
        }

        private void MemberAddForms_Load(object sender, EventArgs e)
        {

        }

        private void nameText_Enter(object sender, EventArgs e)
        {
            if (nameText.Text == "Ім'я")
            {
                nameText.Text = "";
                nameText.ForeColor = Color.Black;
            }
        }

        private void nameText_Leave(object sender, EventArgs e)
        {
            if (nameText.Text == "")
            {
                nameText.Text = "Ім'я";
                nameText.ForeColor = Color.Silver;
            }
        }

        private void secondText_Enter(object sender, EventArgs e)
        {
            if (nameText.Text == "Прізвище")
            {
                nameText.Text = "";
                nameText.ForeColor = Color.Black;
            }
        }

        private void secondText_Leave(object sender, EventArgs e)
        {
            if (nameText.Text == "")
            {
                nameText.Text = "Прізвище";
                nameText.ForeColor = Color.Silver;
            }
        }

        private void lastText_Enter(object sender, EventArgs e)
        {
            if (nameText.Text == "По-батькові")
            {
                nameText.Text = "";
                nameText.ForeColor = Color.Black;
            }
        }

        private void lastText_Leave(object sender, EventArgs e)
        {
            if (nameText.Text == "")
            {
                nameText.Text = "По-батькові";
                nameText.ForeColor = Color.Silver;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddMemberBindingModel member;
        }

        public MemberAddForms()
        {
            InitializeComponent();
        }
    }
}
