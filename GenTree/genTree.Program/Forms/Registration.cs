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
    public partial class Registration : Form
    {
        private string _registrationUrl = "/api/Account/Register";
        public Registration()
        {
            _registrationUrl = MainForm.ServerUrl + _registrationUrl;
            InitializeComponent();
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

        private void Registration_Load(object sender, EventArgs e)
        {
            int year = DateTime.Today.Year;
         
            for (int i = 1900; i <= year; i++)
            {
                Year.Items.Add(i);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
                  RegisterBindingModel registerData = new RegisterBindingModel()
                  {
                      FirstName = nameText.Text,
                      LastName =  secondText.Text,
                      SecondName = lastText.Text,
                      DateOfBith = new DateTime(Convert.ToInt32(Year.SelectedItem),Mounth.SelectedIndex+1,Convert.ToInt32(Day.SelectedItem)),
                      Photo = imageToByteArray(pictureBox1.Image),
                      Email = emailText.Text,
                      Password = textBox1.Text,
                      ConfirmPassword = textBox2.Text
                       
                  };
            RequestController.HttpPOST(_registrationUrl, JsonConvert.SerializeObject(registerData), "application/json");
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

    }
}
