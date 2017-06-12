using GenTree.Program.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenTree.Program.Controller;
using Newtonsoft.Json;


namespace GenTree.Program
{
   
    public partial class MainForm : Form
    {
        public static string ServerUrl;
        private string _loginUrl = "/token";

        public MainForm()
        {
            ServerUrl = GetUrlFromConfig();
            InitializeComponent();
            _loginUrl = ServerUrl + _loginUrl;
        }

       private string GetUrlFromConfig()
       {
           var pathToFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)+"\\config.txt";
            
           if (System.IO.File.Exists(pathToFile))
           {
               return File.ReadAllText(pathToFile);
           }
           else
           {
               File.WriteAllText(pathToFile, "http://localhost/GenTree");
                return File.ReadAllText(pathToFile);
           }
          

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
            var token = RequestController.HttpPOST(_loginUrl,
              "grant_type=password&username=" + Email.Text + "&password=" + Password.Text, "application/x-www-form-urlencoded");
            Acces acces = JsonConvert.DeserializeObject<Acces>(token.Result);
           
             GenTreeForm genTree = new GenTreeForm(acces);
            genTree.Show();
            this.Hide();
        
        } 

        private void MainForm_Load(object sender, EventArgs e)
        {
          
        }
    }
}
