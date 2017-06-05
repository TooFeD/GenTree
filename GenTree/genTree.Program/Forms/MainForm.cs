using GenTree.Program.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Controller;


namespace GenTree.Program
{
   
    public partial class MainForm : Form
    {
        private string _loginUrl = "http://localhost:55161/token";

        public MainForm()
        {
            InitializeComponent();
        }

        private void Email_Enter(object sender, EventArgs e)
        {
            if(Email.Text == "Email")
            {
                Email.Text = "";
                Email.ForeColor = Color.Black;
            }
        }

        private void Email_Leave(object sender, EventArgs e)
        {
            if(Email.Text == "")
            {
                Email.Text = "Email";
                Email.ForeColor = Color.Silver;
            }
        }

        private void Password_Enter(object sender, EventArgs e)
        {
            if(Password.Text == "Пароль")
            {
                Password.Text = "";
                Password.ForeColor = Color.Black;
            }
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if(Password.Text == "")
            {
                Password.Text = "Пароль";
                Password.ForeColor = Color.Silver;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Registration regForm = new Registration();
            regForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          var s = RequestController.HttpPOST(_loginUrl,
                "grant_type=password&username=" + Email.Text + "&password=" + Password.Text, null);
            Debug.Write(s);
        }
    }
}
