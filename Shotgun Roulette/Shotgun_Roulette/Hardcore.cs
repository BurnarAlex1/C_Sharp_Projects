using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;
using System.Media;

namespace WindowsFormsApp2
{
    
    public partial class Hardcore : Form
    {
        private int winner;
        private int secretBlankShots;
        private int secretLiveShots;
        private bool doubleDamage;
        private int knownShot;
        private int cuff_status;
        private int secret_red_hearts;
        private int secret_blue_hearts;
        private string red_player;
        private string blue_player;
        public Hardcore(string bluename,string redname)
        {
            InitializeComponent();
            doubleDamage = false;
            knownShot = 0;
            cuff_status = 0;
            winner = 0;
            label1.Text = redname;
            label2.Text = bluename;
            red_player = redname;
            blue_player = bluename;
            secret_red_hearts = 10;
            secret_blue_hearts = 10;
            
        }

        private void p2Button_Click(object sender, EventArgs e)
        {
            
            if (knownShot == 1)//known live shot
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blast.wav");
                player.Play();
                MessageBox.Show("Boom!");
                secret_blue_hearts = secret_blue_hearts - 1;

                if (doubleDamage == true)//double damage
                {
                    MessageBox.Show("The blast does double damage!");
                    secret_blue_hearts = secret_blue_hearts - 1;
                    doubleDamage = false;
                }

                if (secret_blue_hearts <= 0)
                {
                    MessageBox.Show(blue_player+" has won!");
                    winner = 1;
                    this.Close();

                }

                //change player 
                
                if ((String)pictureBox3.Tag == "p2")
                {
                    if (cuff_status == 1)
                    {
                        MessageBox.Show(red_player+" is no longer cuffed!");
                        cuff_status = 0;
                    }
                    else
                    {
                        pictureBox3.Image = Resources.p1;
                        pictureBox3.Tag = "p1";
                    }
                    
                }
                else if ((String)pictureBox3.Tag == "p1")
                {
                    if (cuff_status == 2)
                    {
                        MessageBox.Show(blue_player+" is no longer cuffed!");
                        cuff_status = 0;
                    }
                    else
                    {
                        pictureBox3.Image = Resources.p2;
                        pictureBox3.Tag = "p2";
                    }
                    
                }
                knownShot = 0;
                Random rnd = new Random();
                int blankRoundsAux = secretBlankShots;
                int liveRoundsAux = secretLiveShots;


                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player2.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
            else if (knownShot == -1)//known blank
            {
                //blank shot
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
                player.Play();
                MessageBox.Show("Clink!");

                //change player only if p1 shot p2
                if ((String)pictureBox3.Tag == "p1")
                {
                    if (cuff_status == 2)
                    {
                        MessageBox.Show(blue_player+" is no longer cuffed!");
                        cuff_status = 0;
                    }
                    else
                    {
                        pictureBox3.Image = Resources.p2;
                        pictureBox3.Tag = "p2";
                    }
                    
                }
                knownShot = 0;

                Random rnd = new Random();
                int blankRoundsAux = secretBlankShots;
                int liveRoundsAux = secretLiveShots;


                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player2.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
            else//no known shot
            {
                
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                if (liveRounds.Text != "?")
                {
                    liveRoundsAux = Int32.Parse(liveRounds.Text);
                    blankRoundsAux = Int32.Parse(blankRounds.Text);
                    secretLiveShots = liveRoundsAux;
                    secretBlankShots = blankRoundsAux;
                    liveRounds.Text = "?";
                    blankRounds.Text = "?";
                }
                else
                {
                    liveRoundsAux = secretLiveShots;
                    blankRoundsAux = secretBlankShots;
                }

                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blast.wav");
                    player.Play();
                    MessageBox.Show("Boom!");
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;

                    secret_blue_hearts = secret_blue_hearts - 1;


                    if (doubleDamage == true)//double damage
                    {
                        MessageBox.Show("The blast does double damage!");
                        secret_blue_hearts = secret_blue_hearts - 1;
                        doubleDamage = false;
                    }

                    if (secret_blue_hearts <= 0)
                    {
                        MessageBox.Show(red_player+" has won!");
                        winner = 1;
                        this.Close();

                    }

                    //change player 
                    if ((String)pictureBox3.Tag == "p2")
                    {
                        if (cuff_status == 1)
                        {
                            MessageBox.Show(red_player+" is no longer cuffed!");
                            cuff_status = 0;
                        }
                        else
                        {
                            pictureBox3.Image = Resources.p1;
                            pictureBox3.Tag = "p1";
                        }
                        
                    }
                    else if ((String)pictureBox3.Tag == "p1")
                    {
                        if (cuff_status == 2)
                        {
                            MessageBox.Show(blue_player+" is no longer cuffed!");
                            cuff_status = 0;
                        }
                        else
                        {
                            pictureBox3.Image = Resources.p2;
                            pictureBox3.Tag = "p2";
                        }
                        
                    }
                }
                else
                {
                    //blank shot
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
                    player.Play();
                    MessageBox.Show("Clink!");
                    blankRoundsAux = blankRoundsAux - 1;
                    secretBlankShots = blankRoundsAux;

                    //change player only if p1 shot p2
                    if ((String)pictureBox3.Tag == "p1")
                    {
                        if (cuff_status == 2)
                        {
                            MessageBox.Show(blue_player+" is no longer cuffed!");
                            cuff_status = 0;
                        }
                        else
                        {
                            pictureBox3.Image = Resources.p2;
                            pictureBox3.Tag = "p2";
                        }
                        
                    }

                }
                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
            
            
        
        }

        private void p1Button_Click(object sender, EventArgs e)
        {
            if (knownShot == 1)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blast.wav");
                player.Play();
                MessageBox.Show("Boom!");
                secret_red_hearts = secret_red_hearts - 1;


                if (doubleDamage == true)//double damage
                {
                    MessageBox.Show("The blast does double damage!");
                    secret_red_hearts = secret_red_hearts - 1;
                    doubleDamage = false;
                }

                if (secret_red_hearts <= 0)
                {
                    MessageBox.Show(blue_player+" has won!");
                    winner = 2;
                    this.Close();

                }

                //change player 
                if ((String)pictureBox3.Tag == "p2")
                {
                    if (cuff_status == 1)
                    {
                        MessageBox.Show(red_player+" is no longer cuffed!");
                        cuff_status = 0;
                    }
                    else
                    {
                        pictureBox3.Image = Resources.p1;
                        pictureBox3.Tag = "p1";
                    }
                    
                }
                else if ((String)pictureBox3.Tag == "p1")
                {
                    if (cuff_status == 2)
                    {
                        MessageBox.Show(blue_player+" is no longer cuffed!");
                        cuff_status = 0;
                    }
                    else
                    {
                        pictureBox3.Image = Resources.p2;
                        pictureBox3.Tag = "p2";
                    }
                    
                }
                knownShot = 0;

                Random rnd = new Random();
                int blankRoundsAux = secretBlankShots;
                int liveRoundsAux = secretLiveShots;


                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player2.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
            else if (knownShot == -1)
            {
                //blank shot
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
                player.Play();
                MessageBox.Show("Clink!");

                //change player only if p2 shot p1
                if ((String)pictureBox3.Tag == "p2")
                {
                    if (cuff_status == 1)
                    {
                        MessageBox.Show(red_player+" is no longer cuffed!");
                        cuff_status = 0;
                    }
                    else
                    {
                        pictureBox3.Image = Resources.p2;
                        pictureBox3.Tag = "p1";
                    }
                    
                }
                knownShot = 0;

                Random rnd = new Random();
                int blankRoundsAux = secretBlankShots;
                int liveRoundsAux = secretLiveShots;


                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player2.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
            else//no known shot
            {
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                if (liveRounds.Text != "?")
                {
                    liveRoundsAux = Int32.Parse(liveRounds.Text);
                    blankRoundsAux = Int32.Parse(blankRounds.Text);
                    secretLiveShots = liveRoundsAux;
                    secretBlankShots = blankRoundsAux;
                    liveRounds.Text = "?";
                    blankRounds.Text = "?";
                }
                else
                {
                    liveRoundsAux = secretLiveShots;
                    blankRoundsAux = secretBlankShots;
                }
                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blast.wav");
                    player.Play();
                    MessageBox.Show("Boom!");
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;

                    secret_red_hearts = secret_red_hearts - 1;
                    if (doubleDamage == true)//double damage
                    {
                        MessageBox.Show("The blast does double damage!");
                        secret_red_hearts = secret_red_hearts - 1;
                        doubleDamage = false;
                    }

                    if (secret_red_hearts <= 0)
                    {
                        MessageBox.Show(blue_player+" has won!");
                        winner = 2;
                        this.Close();

                    }
                    //change player 
                    if ((String)pictureBox3.Tag == "p2")
                    {
                        if (cuff_status == 1)
                        {
                            MessageBox.Show(red_player+" is no longer cuffed!");
                            cuff_status = 0;
                        }
                        else
                        {
                            pictureBox3.Image = Resources.p1;
                            pictureBox3.Tag = "p1";
                        }
                        
                    }
                    else if ((String)pictureBox3.Tag == "p1")
                    {
                        if (cuff_status == 2)
                        {
                            MessageBox.Show(blue_player+" is no longer cuffed!");
                            cuff_status = 0;
                        }
                        else
                        {
                            pictureBox3.Image = Resources.p2;
                            pictureBox3.Tag = "p2";
                        }
                        
                    }
                }
                else
                {
                    //blank shot
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
                    player.Play();
                    MessageBox.Show("Clink!");
                    blankRoundsAux = blankRoundsAux - 1;
                    secretBlankShots = blankRoundsAux;

                    //change player only if p2 shot p1
                    if ((String)pictureBox3.Tag == "p2")
                    {
                        if (cuff_status == 1)
                        {
                            MessageBox.Show(red_player+" is no longer cuffed!");
                            cuff_status = 0;
                        }
                        else
                        {
                            pictureBox3.Image = Resources.p1;
                            pictureBox3.Tag = "p1";
                        }
                        
                    }

                }
                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;

                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
            
            
        }

        

        

        private void hourGlassButtonP2_Click(object sender, EventArgs e)
        {
            
            if (Int32.Parse(hourGlassButtonP2.Text)>0)//if player 2 has an hourglass
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(hourGlassButtonP2.Text)-1;
                hourGlassButtonP2.Text = "" + hourGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                if (liveRounds.Text != "?")
                {
                    liveRoundsAux = Int32.Parse(liveRounds.Text);
                    blankRoundsAux = Int32.Parse(blankRounds.Text);
                    secretLiveShots = liveRoundsAux;
                    secretBlankShots = blankRoundsAux;
                    liveRounds.Text = "?";
                    blankRounds.Text = "?";
                }
                else
                {
                    liveRoundsAux = secretLiveShots;
                    blankRoundsAux = secretBlankShots;
                }
                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    MessageBox.Show("You rack the shotgun and a live round falls out!");
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;
                }
                else
                {
                    MessageBox.Show("You rack the shotgun and a blank round falls out!");
                    blankRoundsAux = blankRoundsAux - 1;
                    secretBlankShots = blankRoundsAux;
                }

                if (blankRoundsAux == 0 && liveRoundsAux == 0)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                    player.Play();
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
        }

        private void hourGlassButtonP1_Click(object sender, EventArgs e)
        {
            
            if (Int32.Parse(hourGlassButtonP1.Text) > 0)//if player has an hourglass
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(hourGlassButtonP1.Text) - 1;
                hourGlassButtonP1.Text = "" + hourGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                if (liveRounds.Text != "?")
                {
                    liveRoundsAux = Int32.Parse(liveRounds.Text);
                    blankRoundsAux = Int32.Parse(blankRounds.Text);
                    secretLiveShots = liveRoundsAux;
                    secretBlankShots = blankRoundsAux;
                    liveRounds.Text = "?";
                    blankRounds.Text = "?";
                }
                else
                {
                    liveRoundsAux = secretLiveShots;
                    blankRoundsAux = secretBlankShots;
                }
                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    MessageBox.Show("You rack the shotgun and a live round falls out!");
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;
                }
                else
                {
                    MessageBox.Show("You rack the shotgun and a blank round falls out!");
                    blankRoundsAux = blankRoundsAux - 1;
                    secretBlankShots = blankRoundsAux;
                }

                if (liveRoundsAux == 0 && blankRoundsAux == 0)
                {
                    MessageBox.Show("Inserting new rounds into the shotgun!");
                    int lRounds = rnd.Next(1, 5);
                    liveRounds.Text = "" + lRounds;
                    int bRounds = rnd.Next(1, 5);
                    if (lRounds + bRounds > 8)
                    {
                        bRounds = 8 - lRounds;
                    }
                    blankRounds.Text = "" + bRounds;
                    int items = rnd.Next(1, 5);
                    giveItems(items);
                }
            }
        }

        private void swordButtonP2_Click(object sender, EventArgs e)
        {
            
            if (Int32.Parse(swordButtonP2.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next round will do double damage!");
                    int swordButtonAux = Int32.Parse(swordButtonP2.Text)-1;
                    swordButtonP2.Text = ""+swordButtonAux;
                }
                
            }
        }

        private void swordButtonP1_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(swordButtonP1.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next round will do double damage!");
                    int swordButtonAux = Int32.Parse(swordButtonP1.Text) - 1;
                    swordButtonP1.Text = "" + swordButtonAux;
                }

            }
        }

        private void spyglassButtonP2_Click(object sender, EventArgs e)
        {
            if (knownShot==0 && Int32.Parse(spyGlassButtonP2.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(spyGlassButtonP2.Text) - 1;
                spyGlassButtonP2.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                if (liveRounds.Text != "?")
                {
                    liveRoundsAux = Int32.Parse(liveRounds.Text);
                    blankRoundsAux = Int32.Parse(blankRounds.Text);
                    secretLiveShots = liveRoundsAux;
                    secretBlankShots = blankRoundsAux;
                    liveRounds.Text = "?";
                    blankRounds.Text = "?";
                }
                else
                {
                    liveRoundsAux = secretLiveShots;
                    blankRoundsAux = secretBlankShots;
                }
                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    MessageBox.Show("The next shot is a live round!");
                    knownShot = 1;
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;
                }
                else
                {
                    MessageBox.Show("The next shot is a blank round!");
                    knownShot = -1;
                    blankRoundsAux = blankRoundsAux - 1;
                    secretBlankShots = blankRoundsAux;
                }
            } 
        }

        private void spyGlassButtonP1_Click(object sender, EventArgs e)
        {
            
            if (knownShot==0 && Int32.Parse(spyGlassButtonP1.Text)>0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(spyGlassButtonP1.Text) - 1;
                spyGlassButtonP1.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                if (liveRounds.Text != "?")
                {
                    liveRoundsAux = Int32.Parse(liveRounds.Text);
                    blankRoundsAux = Int32.Parse(blankRounds.Text);
                    secretLiveShots = liveRoundsAux;
                    secretBlankShots = blankRoundsAux;
                    liveRounds.Text = "?";
                    blankRounds.Text = "?";
                }
                else
                {
                    liveRoundsAux = secretLiveShots;
                    blankRoundsAux = secretBlankShots;
                }
                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    MessageBox.Show("The next shot is a live round!");
                    knownShot = 1;
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;
                }
                else
                {
                    MessageBox.Show("The next shot is a blank round!");
                    knownShot = -1;
                    blankRoundsAux = blankRoundsAux - 1;
                    secretBlankShots = blankRoundsAux;
                }
            }
            
        }

        private void giveItems(int items)
        {
            Random rnd = new Random();
            int itemNr;
            string message = "";
            
            message = message + "Each player receives " + items + " items!\n\n";
            
            message = message + "The Red Player Received:\n";
            for (int i = items; i > 0; i--)
            {
                itemNr = rnd.Next(2, 6);
                switch (itemNr)
                {
                    case 2:
                        message = message + "Sword\n";
                        int swordAux = Int32.Parse(swordButtonP1.Text) + 1;
                        swordButtonP1.Text = "" + swordAux;
                        break;
                    case 3:
                        message = message + "Handcuffs\n";
                        int handcuffAux = Int32.Parse(handcuffsButtonP1.Text) + 1;
                        handcuffsButtonP1.Text = "" + handcuffAux;
                        break;
                    case 4:
                        message = message + "Hourglass\n";
                        int hourglassAux = Int32.Parse(hourGlassButtonP1.Text) + 1;
                        hourGlassButtonP1.Text = "" + hourglassAux;
                        break;
                    case 5:
                        message = message + "Spyglass\n";
                        int spyglassAux = Int32.Parse(spyGlassButtonP1.Text) + 1;
                        spyGlassButtonP1.Text = "" + spyglassAux;
                        break;
                    default:
                        MessageBox.Show("Out of scope error!!");
                        break;

                }
            }
            message = message + "\nThe Blue Player Received:\n";
            for (int i = items; i > 0; i--)
            {
                
                itemNr = rnd.Next(2, 6);
                switch (itemNr)
                {
                    case 2:
                        message = message + "Sword\n";
                        int swordAux = Int32.Parse(swordButtonP2.Text) + 1;
                        swordButtonP2.Text = "" + swordAux;
                        break;
                    case 3:
                        message = message + "Handcuffs\n";
                        int handcuffAux = Int32.Parse(handcuffsButtonP2.Text) + 1;
                        handcuffsButtonP2.Text = "" + handcuffAux;
                        break;
                    case 4:
                        message = message + "Hourglass\n";
                        int hourglassAux = Int32.Parse(hourGlassButtonP2.Text) + 1;
                        hourGlassButtonP2.Text = "" + hourglassAux;
                        break;
                    case 5:
                        message = message + "Spyglass\n";
                        int spyglassAux = Int32.Parse(spyGlassButtonP2.Text) + 1;
                        spyGlassButtonP2.Text = "" + spyglassAux;
                        break;
                    default:
                        MessageBox.Show("Out of scope error!!");
                        break;


                }
            }
            MessageBox.Show(message);
        }

        private void handcuffsButtonP2_Click(object sender, EventArgs e)
        {   
            if (cuff_status==0 && Int32.Parse(handcuffsButtonP2.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\handcuff_sound.wav");
                player2.Play();
                cuff_status = 1;
                int handcuffAux = Int32.Parse(handcuffsButtonP2.Text) - 1;
                handcuffsButtonP2.Text = "" + handcuffAux;
                MessageBox.Show(red_player+" has been handcuffed! Their round will be skipped!");
            }
        }

        private void handcuffsButtonP1_Click(object sender, EventArgs e)
        {
            if (cuff_status == 0 && Int32.Parse(handcuffsButtonP1.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\handcuff_sound.wav");
                player2.Play();
                cuff_status = 2;
                int handcuffAux = Int32.Parse(handcuffsButtonP1.Text) - 1;
                handcuffsButtonP1.Text = "" + handcuffAux;
                MessageBox.Show(blue_player+" has been handcuffed! Their round will be skipped!");
            }
        }

        public int check_winner()
        {
            return this.winner;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (secret_blue_hearts == 5)
            {
                secret_blue_hearts++;
            }
            else
            {
                secret_blue_hearts--;
            }
            button5.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (secret_blue_hearts == 2)
            {
                secret_blue_hearts++;
            }
            else
            {
                secret_blue_hearts--;
            }
            button1.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            p2Lives.Text = "" + secret_blue_hearts;
            p1Lives.Text = "" + secret_red_hearts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (secret_blue_hearts == 1)
            {
                secret_blue_hearts++;
            }
            else
            {
                secret_blue_hearts--;
            }
            button2.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (secret_red_hearts == 5)
            {
                secret_red_hearts++;
            }
            else
            {
                secret_red_hearts--;
            }
            button6.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (secret_red_hearts == 2)
            {
                secret_red_hearts++;
            }
            else
            {
                secret_red_hearts--;
            }
            button4.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (secret_red_hearts == 1)
            {
                secret_red_hearts++;
            }
            else
            {
                secret_red_hearts--;
            }
            button3.Hide();
        }
    }
}
