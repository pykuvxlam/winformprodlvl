using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4__ziya_
{
    public partial class Form1 : Form
    {
        private Random random;

        public Form1()
        {
            InitializeComponent();   
            random = new Random();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(
                random.Next(256),
                random.Next(256),
                random.Next(256)
            );
        }
    }
}
