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

namespace GenTree.Program
{
    public partial class MembersAddForm : Form
    {
      //  public string apiUrl = "/api/"
        public MembersAddForm()
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddMemberBindingModel member = new AddMemberBindingModel()
            {
                FirstName = nameText.Text,
                LastName = secondText.Text,
                SecondName = lastText.Text,
                DateOfBirth = new DateTime(Convert.ToInt32(Year.SelectedItem), Mounth.SelectedIndex + 1, Convert.ToInt32(Day.SelectedItem)),
                Photo = imageToByteArray(pictureBox1.Image),
                Sex = checkBox1.Checked?checkBox1.Text:checkBox2.Text,
                DateOfDeth = (comboBox2.SelectedIndex>=0)?new DateTime(Convert.ToInt32(comboBox1.SelectedItem), comboBox2.SelectedIndex + 1, Convert.ToInt32(comboBox3.SelectedItem)):new DateTime(1111,11,11),
                Address = textBox1.Text,
                OtherInfo = textBox2.Text
            };
         //   RequestController.HttpPOST(_registrationUrl, JsonConvert.SerializeObject(registerData), "application/json");
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, imageIn.RawFormat);
            return ms.ToArray();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            checkBox2.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = false;
        }
    }
}
