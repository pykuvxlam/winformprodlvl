using System;
using System.Drawing;
using System.Windows.Forms;


namespace WinFormsApp4_svetofor_ziya_
{
    public partial class Form1 : Form
    {
        private Panel redLight;
        private Panel yellowLight;
        private Panel greenLight;
        private System.Windows.Forms.Timer timer; 
        private int state = 0; 
        private int fadeStep = 0;
        private Color activeColor;
        private Color targetColor;
        private Panel currentPanel;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.redLight = new Panel();
            this.yellowLight = new Panel();
            this.greenLight = new Panel();
            this.timer = new System.Windows.Forms.Timer(); 

            
            this.ClientSize = new Size(200, 400);
            this.Text = "Светофор";

           
            redLight.Size = new Size(100, 100);
            redLight.Location = new Point(50, 30);
            redLight.BackColor = Color.Gray; 
           
            redLight.Region = new Region(new Rectangle(0, 0, 100, 100));
            this.Controls.Add(redLight);

            
            yellowLight.Size = new Size(100, 100);
            yellowLight.Location = new Point(50, 140);
            yellowLight.BackColor = Color.Gray;
            yellowLight.Region = new Region(new Rectangle(0, 0, 100, 100));
            this.Controls.Add(yellowLight);

            
            greenLight.Size = new Size(100, 100);
            greenLight.Location = new Point(50, 250);
            greenLight.BackColor = Color.Gray;
            greenLight.Region = new Region(new Rectangle(0, 0, 100, 100));
            this.Controls.Add(greenLight);

            
            timer.Interval = 100; 
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (fadeStep == 0) 
            {
               
                redLight.BackColor = Color.Gray;
                yellowLight.BackColor = Color.Gray;
                greenLight.BackColor = Color.Gray;

                
                if (state == 0) currentPanel = redLight;
                else if (state == 1) currentPanel = yellowLight;
                else currentPanel = greenLight;

                activeColor = Color.Gray;
                if (state == 0) targetColor = Color.Red;
                else if (state == 1) targetColor = Color.Yellow;
                else targetColor = Color.Green;

                fadeStep = 10; 
            }
            else
            {
                
                int r = activeColor.R + (targetColor.R - activeColor.R) * (11 - fadeStep) / 10;
                int g = activeColor.G + (targetColor.G - activeColor.G) * (11 - fadeStep) / 10;
                int b = activeColor.B + (targetColor.B - activeColor.B) * (11 - fadeStep) / 10;

                currentPanel.BackColor = Color.FromArgb(r, g, b);

                fadeStep--;
                if (fadeStep == 0)
                {
                   
                    System.Windows.Forms.Timer delay = new System.Windows.Forms.Timer(); 
                    delay.Interval = 2000;
                    delay.Tick += (s, ev) =>
                    {
                        delay.Stop();
                        state = (state + 1) % 3;
                    };
                    delay.Start();
                }
            }
        }
    }
}
