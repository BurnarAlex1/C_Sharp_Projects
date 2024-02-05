using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2.Properties;

namespace WindowsFormsApp2
{
    public partial class FreeForAll : Form
    {
        private int secretBlankShots;
        private int secretLiveShots;
        private int knownShot;
        private bool doubleDamage;
        private int playerNr;
        private int victoryCondition;
        

        public FreeForAll(string redName,string yellowName,string greenName,string blueName,string purpleName,string orangeName,string pinkName,string brownName)
        {
            InitializeComponent();
            victoryCondition = 7;
            initializePlayers(redName, yellowName, greenName, blueName, purpleName, orangeName, pinkName, brownName);
            secretBlankShots = Int32.Parse(blankShots.Text);
            secretLiveShots = Int32.Parse(liveShots.Text);
            
        }

        private void initializePlayers(string redName, string yellowName, string greenName, string blueName, string purpleName, string orangeName, string pinkName, string brownName)
        {
            if (yellowName.Trim() == "")
            {
                this.yellowName.Text = "Nobody";
                this.yellowButton.Enabled = false;
                this.yellowSword.Enabled = false;
                this.yellowHour.Enabled = false;
                this.yellowSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 2;
                this.playerTurn.BackColor = Color.Yellow;
                this.yellowName.Text = yellowName;
                this.yellowScore.Text = "3";
            }

            if (greenName.Trim() == "")
            {
                this.greenName.Text = "Nobody";
                this.greenButton.Enabled = false;
                this.greenSword.Enabled = false;
                this.greenHour.Enabled = false;
                this.greenSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 3;
                this.playerTurn.BackColor = Color.Green;
                this.greenName.Text = greenName;
                this.greenScore.Text = "3";
            }

            if (blueName.Trim() == "")
            {
                this.blueName.Text = "Nobody";
                this.blueButton.Enabled = false;
                this.blueSword.Enabled = false;
                this.blueHour.Enabled = false;
                this.blueSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 4;
                this.playerTurn.BackColor = Color.Blue;
                this.blueName.Text = blueName;
                this.blueScore.Text = "3";
            }

            if (purpleName.Trim() == "")
            {
                this.purpleName.Text = "Nobody";
                this.purpleButton.Enabled = false;
                this.purpleSword.Enabled = false;
                this.purpleHour.Enabled = false;
                this.purpleSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 5;
                this.playerTurn.BackColor = Color.Purple;
                this.purpleName.Text = purpleName;
                this.purpleScore.Text = "3";
            }

            if (orangeName.Trim() == "")
            {
                this.orangeName.Text = "Nobody";
                this.orangeButton.Enabled = false;
                this.orangeSword.Enabled = false;
                this.orangeHour.Enabled = false;
                this.orangeSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 6;
                this.playerTurn.BackColor = Color.Orange;
                this.orangeName.Text = orangeName;
                this.orangeScore.Text = "3";
            }

            if (pinkName.Trim() == "")
            {
                this.pinkName.Text = "Nobody";
                this.pinkButton.Enabled = false;
                this.pinkSword.Enabled = false;
                this.pinkHour.Enabled = false;
                this.pinkSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 7;
                this.playerTurn.BackColor = Color.Pink;
                this.pinkName.Text = pinkName;
                this.pinkScore.Text = "3";
            }

            if (brownName.Trim() == "")
            {
                this.brownName.Text = "Nobody";
                this.brownButton.Enabled = false;
                this.brownSword.Enabled = false;
                this.brownHour.Enabled = false;
                this.brownSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 8;
                this.playerTurn.BackColor = Color.SaddleBrown;
                this.brownName.Text = brownName;
                this.brownScore.Text = "3";
            }

            if (redName.Trim() == "")
            {
                this.redName.Text = "Nobody";
                this.redButton.Enabled = false;
                this.redSword.Enabled = false;
                this.redHour.Enabled = false;
                this.redSpy.Enabled = false;
                victoryCondition--;
            }
            else
            {
                playerNr = 1;
                this.playerTurn.BackColor = Color.Red;
                this.redName.Text = redName;
                this.redScore.Text = "3";
            }

        }

        

        private void shooting_function(int p,int plives)
        {
            //shots hidden
            liveShots.Text = "?";
            blankShots.Text = "?";

            if (knownShot == 1)
            {
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blast.wav");
                player.Play();
                MessageBox.Show("Boom!");
                
                plives = plives - 1;
                lifeChange(plives, p);

                if (doubleDamage == true)//double damage
                {
                    MessageBox.Show("The blast does double damage!");
                    plives = plives - 1;
                    lifeChange(plives, p);
                    doubleDamage = false;
                }

                if (plives <= 0)
                {
                    playerLost(p);
                }

                //change player 
                nextPlayer();

                knownShot = 0;
                insertRounds();
            }
            else if (knownShot == -1)
            {
                //blank shot
                System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blank.wav");
                player.Play();
                MessageBox.Show("Clink!");

                //change player only if p2 shot p1
                if (p != playerNr)
                {
                    nextPlayer();
                }
                

                knownShot = 0;
                insertRounds();

            }
            else//no known shot
            {
                
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;
                int shotfired = rnd.Next(1, liveRoundsAux + blankRoundsAux + 1);

                //live shot
                if (shotfired <= liveRoundsAux)
                {
                    System.Media.SoundPlayer player = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\shotgun_blast.wav");
                    player.Play();
                    MessageBox.Show("Boom!");
                    liveRoundsAux = liveRoundsAux - 1;
                    secretLiveShots = liveRoundsAux;

                    plives = plives - 1;
                    lifeChange(plives, p);
                    if (doubleDamage == true)//double damage
                    {
                        MessageBox.Show("The blast does double damage!");
                        plives = plives - 1;
                        lifeChange(plives, p);
                        doubleDamage = false;
                    }

                    if (plives <= 0)
                    {
                        playerLost(p);

                    }
                    //change player 
                    nextPlayer();



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
                    if (p != playerNr)
                    {
                        nextPlayer();
                    }
                    

                }
                insertRounds();
            }
        }

        private void lifeChange(int lives,int playerNr)
        {
            switch (playerNr)
            {
                case 1:
                    redScore.Text = "" + lives;
                    break;
                case 2:
                    yellowScore.Text = "" + lives;
                    break;
                case 3:
                    greenScore.Text = "" + lives;
                    break;
                case 4:
                    blueScore.Text = "" + lives;
                    break;
                case 5:
                    purpleScore.Text = "" + lives;
                    break;
                case 6:
                    orangeScore.Text = "" + lives;
                    break;
                case 7:
                    pinkScore.Text = "" + lives;
                    break;
                case 8:
                    brownScore.Text = "" + lives;
                    break;
                default:
                    MessageBox.Show("Error. Out of bounds Switch");
                    break;
                    
            }
        }

        private void insertRounds()
        {
            Random rnd = new Random();
            int blankRoundsAux = secretBlankShots;
            int liveRoundsAux = secretLiveShots;


            if (blankRoundsAux == 0 && liveRoundsAux == 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\reload_sound.wav");
                player2.Play();
                MessageBox.Show("Inserting new rounds into the shotgun!");
                int lRounds = rnd.Next(1, 5);
                liveShots.Text = "" + lRounds;
                secretLiveShots = lRounds;
                int bRounds = rnd.Next(1, 5);
                if (lRounds + bRounds > 8)
                {
                    bRounds = 8 - lRounds;
                }
                blankShots.Text = "" + bRounds;
                secretBlankShots = bRounds;
                giveItems();
            }
        }

        private void giveItems()
        {
            Random rnd = new Random();
            int itemNr;
            
            
            for(int i = 1; i < 9; i++)
            {
                itemNr = rnd.Next(1, 4);
                selectPlayerForItems(i, itemNr);
            }
            

        }

        private void selectPlayerForItems(int playerGiven,int itemNr)
        {
            switch (playerGiven)
            {
                case 1:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(redSword.Text) + 1;
                            redSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(redHour.Text) + 1;
                            redHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(redSpy.Text) + 1;
                            redSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 2:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(yellowSword.Text) + 1;
                            yellowSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(yellowHour.Text) + 1;
                            yellowHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(yellowSpy.Text) + 1;
                            yellowSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 3:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(greenSword.Text) + 1;
                            greenSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(greenHour.Text) + 1;
                            greenHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(greenSpy.Text) + 1;
                            greenSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 4:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(blueSword.Text) + 1;
                            blueSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(blueHour.Text) + 1;
                            blueHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(blueSpy.Text) + 1;
                            blueSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 5:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(purpleSword.Text) + 1;
                            purpleSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(purpleHour.Text) + 1;
                            purpleHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(purpleSpy.Text) + 1;
                            purpleSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 6:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(orangeSword.Text) + 1;
                            orangeSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(orangeHour.Text) + 1;
                            orangeHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(orangeSpy.Text) + 1;
                            orangeSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 7:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(pinkSword.Text) + 1;
                            pinkSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(pinkHour.Text) + 1;
                            pinkHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(pinkSpy.Text) + 1;
                            pinkSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;
                case 8:
                    switch (itemNr)
                    {
                        case 1:
                            int swordAux = Int32.Parse(brownSword.Text) + 1;
                            brownSword.Text = "" + swordAux;
                            break;
                        case 2:
                            int hourglassAux = Int32.Parse(brownHour.Text) + 1;
                            brownHour.Text = "" + hourglassAux;
                            break;
                        case 3:
                            int spyglassAux = Int32.Parse(brownSpy.Text) + 1;
                            brownSpy.Text = "" + spyglassAux;
                            break;
                        default:
                            MessageBox.Show("Out of scope error!!");
                            break;

                    }
                    break;

            }
        }
        

        private void nextPlayer()
        {
            int check = 0;
            int safe_checks= 0;
            while (check== 0){
                switch (playerNr)
                {
                    case 1:
                        if (Int32.Parse(yellowScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Yellow;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 2:
                        if (Int32.Parse(greenScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Green;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 3:
                        if (Int32.Parse(blueScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Blue;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 4:
                        if (Int32.Parse(purpleScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Purple;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 5:
                        if (Int32.Parse(orangeScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Orange;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 6:
                        if (Int32.Parse(pinkScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Pink;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 7:
                        if (Int32.Parse(brownScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.SaddleBrown;
                            check = 1;
                            playerNr++;
                        }
                        else
                        {
                            playerNr++;
                            safe_checks++;
                        }
                        break;
                    case 8:
                        if (Int32.Parse(redScore.Text) > 0)
                        {
                            playerTurn.BackColor = Color.Red;
                            check = 1;
                            playerNr=1;
                        }
                        else
                        {
                            playerNr=1;
                            safe_checks++;
                        }
                        break;
                    default:
                        MessageBox.Show("Error. Switch out of bounds");
                        check = 1;
                        break;
                }

                if (safe_checks >= 9)
                {
                    check = 1;
                    
                    
                    
                }
            }
            
        }

        private void playerLost(int playerNr)
        {
            switch (playerNr)
            {
                case 1:
                    victoryCondition--;
                    this.redButton.Enabled = false;
                    this.redSword.Enabled = false;
                    this.redHour.Enabled = false;
                    this.redSpy.Enabled = false;
                    break;
                case 2:
                    victoryCondition--;
                    this.yellowButton.Enabled = false;
                    this.yellowSword.Enabled = false;
                    this.yellowHour.Enabled = false;
                    this.yellowSpy.Enabled = false;
                    break;
                case 3:
                    victoryCondition--;
                    this.greenButton.Enabled = false;
                    this.greenSword.Enabled = false;
                    this.greenHour.Enabled = false;
                    this.greenSpy.Enabled = false;
                    break;
                case 4:
                    victoryCondition--;
                    this.blueButton.Enabled = false;
                    this.blueSword.Enabled = false;
                    this.blueHour.Enabled = false;
                    this.blueSpy.Enabled = false;
                    break;
                case 5:
                    victoryCondition--;
                    this.purpleButton.Enabled = false;
                    this.purpleSword.Enabled = false;
                    this.purpleHour.Enabled = false;
                    this.purpleSpy.Enabled = false;
                    break;
                case 6:
                    victoryCondition--;
                    this.orangeButton.Enabled = false;
                    this.orangeSword.Enabled = false;
                    this.orangeHour.Enabled = false;
                    this.orangeSpy.Enabled = false;
                    break;
                case 7:
                    victoryCondition--;
                    this.pinkButton.Enabled = false;
                    this.pinkSword.Enabled = false;
                    this.pinkHour.Enabled = false;
                    this.pinkSpy.Enabled = false;
                    break;
                case 8:
                    victoryCondition--;
                    this.brownButton.Enabled = false;
                    this.brownSword.Enabled = false;
                    this.brownHour.Enabled = false;
                    this.brownSpy.Enabled = false;
                    break;
                default:
                    break;
            }
            if (victoryCondition <= 0)
            {
                MessageBox.Show("We have a winner!");
                //this.Close();
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(redScore.Text);
            shooting_function(1, plives);
        }

        private void yellowButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(yellowScore.Text);
            shooting_function(2, plives);
        }

        private void greenButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(greenScore.Text);
            shooting_function(3, plives);
        }

        private void blueButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(blueScore.Text);
            shooting_function(4, plives);
        }

        private void purpleButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(purpleScore.Text);
            shooting_function(5, plives);
        }

        private void orangeButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(orangeScore.Text);
            shooting_function(6, plives);
        }

        private void pinkButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(pinkScore.Text);
            shooting_function(7, plives);
        }

        private void brownButton_Click(object sender, EventArgs e)
        {
            int plives;
            plives = Int32.Parse(brownScore.Text);
            shooting_function(8, plives);
        }
        private void checkFire()
        {
            Random rnd = new Random();
            int liveRoundsAux = secretLiveShots;
            int blankRoundsAux = secretBlankShots;

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
            insertRounds();
        }

        private void redHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(redHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(redHour.Text) - 1;
                redHour.Text = "" + hourGlassAux;
                checkFire();
                
            }
        }

        private void yellowHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(yellowHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(yellowHour.Text) - 1;
                yellowHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void greenHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(greenHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(greenHour.Text) - 1;
                greenHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void blueHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(blueHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(blueHour.Text) - 1;
                blueHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void purpleHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(purpleHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(purpleHour.Text) - 1;
                purpleHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void orangeHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(orangeHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(orangeHour.Text) - 1;
                orangeHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void pinkHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(pinkHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(pinkHour.Text) - 1;
                pinkHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void brownHour_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(brownHour.Text) > 0)//if player has an hourglass
            {
                liveShots.Text = "?";
                blankShots.Text = "?";
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\rack_sound.wav");
                player2.Play();
                int hourGlassAux = Int32.Parse(brownHour.Text) - 1;
                brownHour.Text = "" + hourGlassAux;
                checkFire();

            }
        }

        private void redSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(redSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(redSword.Text) - 1;
                    redSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void yellowSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(yellowSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(yellowSword.Text) - 1;
                    yellowSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void greenSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(greenSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(greenSword.Text) - 1;
                    greenSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void blueSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(blueSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(blueSword.Text) - 1;
                    blueSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void purpleSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(purpleSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(purpleSword.Text) - 1;
                    purpleSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void orangeSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(orangeSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(orangeSword.Text) - 1;
                    orangeSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void pinkSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(pinkSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(pinkSword.Text) - 1;
                    pinkSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void brownSword_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(brownSword.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\sword_draw.wav");
                player2.Play();
                if (doubleDamage == false)
                {
                    doubleDamage = true;
                    MessageBox.Show("You saw off the shotgun, the next live round will do double damage!");
                    int swordButtonAux = Int32.Parse(brownSword.Text) - 1;
                    brownSword.Text = "" + swordButtonAux;
                }

            }
        }

        private void redSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(redSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(redSpy.Text) - 1;
                redSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;
                
                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;
                
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

        private void yellowSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(yellowSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(yellowSpy.Text) - 1;
                yellowSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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

        private void greenSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(greenSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(greenSpy.Text) - 1;
                greenSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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

        private void blueSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(blueSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(blueSpy.Text) - 1;
                blueSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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

        private void purpleSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(purpleSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(purpleSpy.Text) - 1;
                purpleSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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

        private void orangeSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(orangeSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(orangeSpy.Text) - 1;
                orangeSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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

        private void pinkSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(pinkSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(pinkSpy.Text) - 1;
                pinkSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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

        private void brownSpy_Click(object sender, EventArgs e)
        {
            if (knownShot == 0 && Int32.Parse(brownSpy.Text) > 0)
            {
                System.Media.SoundPlayer player2 = new System.Media.SoundPlayer("D:\\C# Projects\\WindowsFormsApp2\\WindowsFormsApp2\\sounds\\among_us_sound.wav");
                player2.Play();
                int spyGlassAux = Int32.Parse(brownSpy.Text) - 1;
                brownSpy.Text = "" + spyGlassAux;
                Random rnd = new Random();
                int liveRoundsAux;
                int blankRoundsAux;

                liveRoundsAux = secretLiveShots;
                blankRoundsAux = secretBlankShots;

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
    }
}
