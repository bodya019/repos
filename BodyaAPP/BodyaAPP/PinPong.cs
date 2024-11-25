using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BodyaAPP
{
    public partial class PinPong : Form
    {
        private int _speedVer = 5, _speedHor = 5, _speedPlotform = 15;
        
        private int score = 0;

        

        public PinPong()
        {
            InitializeComponent();
        }
        

        private void PinPong_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if ((e.KeyCode == Keys.A || e.KeyCode == Keys.Left) && platform.Left > panel.Left)
            {
                platform.Left -= _speedPlotform;
            }
            else if ((e.KeyCode == Keys.D || e.KeyCode == Keys.Right) && platform.Right < panel.Right)
            {
                platform.Left += _speedPlotform;
            }

            if (e.KeyCode == Keys.R && !timer.Enabled )
            { 
                Random random = new Random();
                ball.Left = random.Next(20, 300);
                ball.Top = random.Next(100, 500);
                score = 0;
                label1.Text = "Результат: 0";
                Ulose.Visible = false;
                timer.Start();
            }
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            ball.Top -= _speedVer;
            ball.Left -= _speedHor;

            if (ball.Top <= panel.Top)
            {
                _speedVer *= -1;
            }
            if (ball.Bottom >= panel.Bottom)
            {
                timer.Stop();
                Ulose.Visible = true;
            }
            if (ball.Left <= panel.Left)
            {
                _speedHor *= -1;
            }
            if (ball.Right >= panel.Right)
            {
                _speedHor *= -1;
            }

            if (ball.Bottom >= platform.Top && ball.Left >= platform.Left && ball.Right <= platform.Right)
            {
                _speedVer *= -1;                
                score++; 
                label1.Text = "Результат: " + score;
                Random random = new Random();
                panel.BackColor = Color.FromArgb(random.Next(100,200), random.Next(100, 200), random.Next(100, 200)) ;
            }
        } 
    }
}
