
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4_ziya_novoe_1_zadanie_
{
    public class Form1 : Form
    {
        private Button knopkaCvet;      
        private ColorDialog oknoCveta;  
        private System.Windows.Forms.Timer timerObratno;
        private Color nachalniyCvet;    

        public Form1()
        {
            SozdatFormu();
        }

        private void SozdatFormu()
        {
            
            nachalniyCvet = this.BackColor;

            
            knopkaCvet = new Button();
            knopkaCvet.Text = "Изменить цвет";
            knopkaCvet.Size = new Size(150, 30);
            knopkaCvet.Location = new Point(30, 30);
            knopkaCvet.Click += IzmenitCvet;

            
            oknoCveta = new ColorDialog();

            
            timerObratno = new System.Windows.Forms.Timer();
            timerObratno.Interval = 5000;
            timerObratno.Tick += VernutCvet;

            
            this.ClientSize = new Size(300, 150);
            this.Controls.Add(knopkaCvet);
            this.Text = "Смена цвета формы";
        }

        
        private void IzmenitCvet(object sender, EventArgs e)
        {
            if (oknoCveta.ShowDialog() == DialogResult.OK)
            {
                this.BackColor = oknoCveta.Color; 
                timerObratno.Start();             
            }
        }

        
        private void VernutCvet(object sender, EventArgs e)
        {
            this.BackColor = nachalniyCvet; 
            timerObratno.Stop();            
        }
    }
}
