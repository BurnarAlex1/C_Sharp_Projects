using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using AxWMPLib;

namespace WindowsFormsApp2
{
    
    public partial class FirstPage : Form
    {
        private bool muted;
        //SoundPlayer backgroundPlayer;
        public FirstPage()
        {
            InitializeComponent();
            muted = false;
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            MXP.URL = @"D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Soundtrack.mp4";
            MXP.settings.playCount = 999;
            MXP.Ctlcontrols.play();

            MXP.Visible = false;
            
  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            GamemodeMenu f3 = new GamemodeMenu();
            f3.ShowDialog();
            this.Show();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
            player2.Play();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            if (muted == false)
            {
                muted = true;
                MXP.Ctlcontrols.pause();
            }
            else
            {
                muted = false;
                MXP.Ctlcontrols.play();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string message;
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            message = "Developer:\nBurnar Alex\n\n Testers:\nIulia\nManu\nViu\nVali\nMeli\nDeni\n";
            MessageBox.Show(message,"Credits");
        }
    }
}
