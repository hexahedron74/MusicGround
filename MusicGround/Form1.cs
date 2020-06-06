using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicGround
{
    public partial class Form1 : Form
    {

        int mov;
        int movX;
        int movY;

        Color first = Color.FromArgb(25, 118, 211);
        Color second = Color.CornflowerBlue;
        Color panel2_Origianl = Color.FromArgb(43, 43, 43);
        Color main = Color.FromArgb(31, 31, 31);
        public Form1()
        {
            InitializeComponent();
            label5.Hide();
            button1.Hide();
            panel3.Hide();
            settings.Hide();
            home2.BringToFront();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void maximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            small_screen.BringToFront();
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void small_screen_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            maximize.BringToFront();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = 1;
            movX = e.X;
            movY = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == 1)
            {
                this.SetDesktopLocation(MousePosition.X - movX, MousePosition.Y - movY);
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button3.BringToFront();
            panel2.BackColor = panel2_Origianl;
            home2.BackColor = main;
            musicPlayer1.BackColor = main;
            label4.Text = "Dark Mode is Running!";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button4.BringToFront();
            panel2.BackColor = second;
            home2.BackColor = first;
            musicPlayer1.BackColor = first;
            label4.Text = "Dark Mode is Off!";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            settings.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            settings.Show();
            settings.BringToFront();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            home2.BringToFront();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            musicPlayer1.BringToFront();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            panel3.Show();
            button15.Show();
            button15.BringToFront();
            panel3.BringToFront();
            label5.Show();
        }

        private void button7_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            label5.Hide();
            panel3.Hide();
            button7.BringToFront();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/channel/UCkjgSQeRNiXBqbPf3kBaCsg?view_as=subscriber");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.naver.com/ithan0704");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/hexahedron74");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://cafe.naver.com/jwareprogrammingnote");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://software.naver.com/software/summary.nhn?softwareId=GWS_003298");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            releaseNote1.BringToFront();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            developer1.BringToFront();
        }
    }
}
