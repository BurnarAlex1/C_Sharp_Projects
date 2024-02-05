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
    public partial class Form1 : Form
    {
        private Player []players;
        private int last_player;
        public Form1(string players)
        {
            
           
            InitializeComponent();
            last_player = -1;
            players = players.Trim();
            string[] split = players.Split(new Char[] { ' ','-' },
                                 StringSplitOptions.RemoveEmptyEntries);
            this.players = new Player[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                
                Player new_player = new Player(split[i]);
                this.players[i] = new_player;
                
            }
            update_scoreboard();
        }

        private void update_scoreboard()
        {
            players_label.Text ="";
            for(int i = 0; i < this.players.Length; i++)
            {
                players[i].check_elimination();
                players_label.Text = players_label.Text+ this.players[i].get_name()+" Wins: " + this.players[i].get_wins()+" Loses: " + this.players[i].get_loses()+" Eliminated:" + this.players[i].get_elimination_status()+"\n";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\Menu_Explosion_Sound.wav");
            player2.Play();
            int check;
            check = 0;
            int p1,p2;
            p1 = -2;
            p2 = -2;
            for (int i = 0; i < players.Length; i++)
            {
                
                if (players[i].get_elimination_status() == false)
                {
                    if (check == 0)
                    {
                        if (last_player != -1)
                        {
                            
                            p2 = last_player;
                            check = 1;
                            i--;
                            last_player = -1;
                        }
                        else
                        {
                            
                            p2 = i;
                            check = 1;
                        }
                        
                    }
                    else
                    {
                        
                        //MessageBox.Show("New Round!!\n\n"+players[p2].get_name() + " is playing as Blue!\n\n"+players[i].get_name() + " is playing as Red!");
                        p1 = i;
                        check = 0;

                        if (p1 == p2)
                        {
                            p1 = -1;
                            p2 = -1;
                        }
                        else
                        {
                            MessageBox.Show("New Round!!\n\n" + players[p2].get_name() + " is playing as Blue!\n\n" + players[i].get_name() + " is playing as Red!");

                        }

                        if (p1 != -1 && p2 != -1 && p1!=-2 && p2!=-2)
                        {
                            
                            Casual c1 = new Casual(players[p2].get_name(), players[p1].get_name());
                            c1.ShowDialog();
                            int winner = c1.check_winner();
                            
                            if (winner == 1)
                            {
                                players[p1].add_victory();
                                players[p2].add_loss();
                            }
                            else
                            {
                                players[p1].add_loss();
                                players[p2].add_victory();
                            }
                            p1 = -1;
                            p2 = -1;
                            update_scoreboard();
                        }
                    }
                }
            }
            last_player = p2;
            if(p1==-2 || p2 == -2)
            {
                MessageBox.Show(players[last_player].get_name()+" has won the tournament!");
                last_player = -1;
            }
            update_scoreboard();

        }
    }
}
