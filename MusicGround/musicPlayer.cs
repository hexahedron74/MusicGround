using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using System.IO;

namespace MusicGround
{
    public partial class musicPlayer : UserControl
    {
        public musicPlayer()
        {
            InitializeComponent();
        }

        private void musicPlayer_Load(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MediaFile file = listBox1.SelectedItem as MediaFile;
            if (file != null)
            {
                wmp.URL = file.path;
                wmp.Ctlcontrols.play();
                button2.BringToFront();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.pause();
            button1.BringToFront();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            wmp.Ctlcontrols.play();
            button2.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex<listBox1.Items.Count -1)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex > 0)
            {
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }
        }

       

        private void wmp_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if(wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                bunifuProgressBar1.MaximumValue = (int)wmp.Ctlcontrols.currentItem.duration;
                timer1.Start();
            }
            else if(wmp.playState==WMPLib.WMPPlayState.wmppsPaused)
            {
                timer1.Stop();
            }
            else if(wmp.playState == WMPLib.WMPPlayState.wmppsStopped)
            {
                timer1.Stop();
                bunifuProgressBar1.Value = 0;
                SendKeys.SendWait("{DOWNARROW}");
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = wmp.Ctlcontrols.currentPositionString;
            label2.Text = wmp.Ctlcontrols.currentItem.durationString.ToString();
            if(wmp.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                bunifuProgressBar1.Value = (int)wmp.Ctlcontrols.currentPosition;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button11.BringToFront();
            wmp.settings.volume = 0;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            button9.BringToFront();
            wmp.settings.volume = trackBar2.Value;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            wmp.settings.volume = trackBar2.Value;
            if(trackBar2.Value == 0)
            {
                button11.BringToFront();
            }
            else
            {
                button9.BringToFront();
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            wmp.settings.setMode("shuffle", true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            wmp.settings.setMode("loop", true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Multiselect = true, ValidateNames = true, Filter = "MP3|*.mp3|WAV|*.wav" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    List<MediaFile> files = new List<MediaFile>();
                    foreach (string fileName in ofd.FileNames)
                    {
                        FileInfo fi = new FileInfo(fileName);
                        files.Add(new MediaFile() { FileName = Path.GetFileNameWithoutExtension(fi.FullName), path = fi.FullName });
                    }
                    listBox1.DataSource = files;
                    listBox1.ValueMember = "path";
                    listBox1.DisplayMember = "FileName";
                }
            }
        }
    }
}
