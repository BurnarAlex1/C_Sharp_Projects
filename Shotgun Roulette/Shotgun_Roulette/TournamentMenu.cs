using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    public partial class TournamentMenu : Form
    {
        
        private int player_nr;
        public TournamentMenu()
        {
            player_nr = 0;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
            player2.Play();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
            player2.Play();
            players_label.Text = "None";
        }

        private void addPlayerButton_Click(object sender, EventArgs e)
        {
            
            string player = this.playerTextBox.Text+"  -  ";
            if (players_label.Text=="None")
            {
                players_label.Text = player;
            }
            else
            {
                players_label.Text = players_label.Text+player;
            }
            playerTextBox.Text = "";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            Form1 f1 = new Form1(this.players_label.Text);
            f1.ShowDialog();
            this.Show();
            
        }

         
    }
}
