using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IcoConverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(pictureBox1.ImageLocation == null)
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            else if (pictureBox2.ImageLocation == null)
                pictureBox2.ImageLocation = openFileDialog1.FileName;
            else if (pictureBox3.ImageLocation == null)
                pictureBox3.ImageLocation = openFileDialog1.FileName;
            else if (pictureBox4.ImageLocation == null)
                pictureBox4.ImageLocation = openFileDialog1.FileName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string[] paths = new string[4];
            paths[0] = pictureBox1.ImageLocation;
            paths[1] = pictureBox2.ImageLocation;
            paths[2] = pictureBox3.ImageLocation;
            paths[3] = pictureBox4.ImageLocation;
            IcoFileConverter.ConvertToIco(paths,saveFileDialog1.FileName);
        }
    }
}
