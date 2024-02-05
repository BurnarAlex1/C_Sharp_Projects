using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class GamemodeMenu : Form
    {
        public GamemodeMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            Casual f2 = new Casual("Player 1","Player 2");
            f2.ShowDialog();
            this.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
            player2.Play();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            TournamentMenu tournamentMenu = new TournamentMenu();
            tournamentMenu.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            Hardcore h1 = new Hardcore("Player 2", "Player 1");
            h1.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            PlayerSelection ps = new PlayerSelection();
            ps.ShowDialog();
            this.Show();
        }
    }
}
