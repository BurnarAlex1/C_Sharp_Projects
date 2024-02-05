using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class PlayerSelection : Form
    {
        public PlayerSelection()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
            player2.Play();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            int check=0;
            this.Hide();
            if (redTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (yellowTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (greenTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (blueTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (purpleTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (orangeTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (pinkTextBox.Text.Trim() == "")
            {
                check++;
            }
            if (brownTextBox.Text.Trim() == "")
            {
                check++;
            }

            if (check < 7)
            {
                FreeForAll fff = new FreeForAll(this.redTextBox.Text, this.yellowTextBox.Text, this.greenTextBox.Text, this.blueTextBox.Text, this.purpleTextBox.Text, this.orangeTextBox.Text, this.pinkTextBox.Text, this.brownTextBox.Text);
                fff.ShowDialog();
            }
            else
            {
                MessageBox.Show("Atleast 2 players are needed for a game!");
            }
            
            this.Show();
        }
    }
}
