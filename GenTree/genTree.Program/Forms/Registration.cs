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

namespace GenTree.Program.Forms
{
    public partial class Registration : Form
    {
        private string _registrationUrl = "http://localhost:55161/api/Account/Register";
        public Registration()
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

        }
    }
}
