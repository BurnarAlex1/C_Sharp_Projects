using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using The_King_s_Gambit;

namespace WindowsFormsApp1
{
    
    public partial class MainGame : Form
    {
        SqlConnection sqlConnection1;
        DataSet ds_main;
        private int decadeCounter;
        private int counter;
        //DataSet ds2_main;
        public MainGame()
        {
            InitializeComponent();
            counter = 0;
            decadeCounter = 0;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                string connectionString = "Data Source=tcp:127.0.0.1,3333;Persist Security Info=True;Initial Catalog=project;" +
                    "User ID=sa;Password=1234;Encrypt=False";
                sqlConnection1 = new SqlConnection(connectionString);
                sqlConnection1.Open();
                sqlConnection1.Close();
                //this.Text = "ok: " + connectionString;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return;
            }


            new_event();
        }

        private void new_event()
        {
            ds_main = new DataSet();
            SqlDataAdapter ad1 = new SqlDataAdapter();
            SqlCommand sel1 = new SqlCommand();
            sel1.Connection = sqlConnection1;
            ad1.SelectCommand = sel1;
            sel1.CommandText = "SELECT TOP 1 * FROM Event ORDER BY NEWID()";
            ad1.Fill(ds_main, "a");

            string name = ds_main.Tables["a"].Rows[0]["EventName"].ToString();
            nameLabel.Text = name;

            string desc = ds_main.Tables["a"].Rows[0]["EventBody"].ToString();
            descLabel.Text = desc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int check = 0;
            int auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Nobility"].ToString());
            if (auxnr >= 0)
            {
                nobilityChange.ForeColor = Color.Green;             
            }
            else
            {
                nobilityChange.ForeColor = Color.Red;
            }
            nobilityChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(nobilityLabel.Text);
            nobilityLabel.Text = ""+auxnr;
            if (auxnr < 0)
            {
                check= 1;
            }
            auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Clergy"].ToString());
            if (auxnr >= 0)
            {
                clergyChange.ForeColor = Color.Green;
            }
            else
            {
                clergyChange.ForeColor = Color.Red;
            }
            clergyChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(clergyLabel.Text);
            clergyLabel.Text = "" + auxnr;
            if (auxnr < 0)
            {
                check = 1;
            }
            auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Commoner"].ToString());
            if (auxnr >= 0)
            {
                commonerChange.ForeColor = Color.Green;
            }
            else
            {
                commonerChange.ForeColor = Color.Red;
            }
            commonerChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(commonerLabel.Text);
            commonerLabel.Text = "" + auxnr;
            if (auxnr < 0)
            {
                check = 1;
            }
            auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Money"].ToString());
            if (auxnr >= 0)
            {
                moneyChange.ForeColor = Color.Green;
            }
            else
            {
                moneyChange.ForeColor = Color.Red;
            }
            moneyChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(moneyLabel.Text);
            moneyLabel.Text = "" + auxnr;
            if (auxnr < 0)
            {
                check = 1;
            }
            auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Army"].ToString());
            if (auxnr >= 0)
            {
                armyChange.ForeColor = Color.Green;
            }
            else
            {
                armyChange.ForeColor = Color.Red;
            }
            armyChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(armyLabel.Text);
            armyLabel.Text = "" + auxnr;
            if (auxnr < 0)
            {
                check = 1;
            }
            auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Land"].ToString());
            if (auxnr >= 0)
            {
                landChange.ForeColor = Color.Green;
            }
            else
            {
                landChange.ForeColor = Color.Red;
            }
            landChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(landLabel.Text);
            landLabel.Text = "" + auxnr;
            if (auxnr < 0)
            {
                check = 1;
            }
            auxnr = Int32.Parse(ds_main.Tables["a"].Rows[0]["Population"].ToString());
            if (auxnr >= 0)
            {
                populationChange.ForeColor = Color.Green;
            }
            else
            {
                populationChange.ForeColor = Color.Red;
            }
            populationChange.Text = "" + auxnr;
            auxnr = auxnr + Int32.Parse(populationLabel.Text);
            populationLabel.Text = "" + auxnr;
            if (auxnr < 0)
            {
                check = 1;
            }

            counter++;
            int aux;
            if (counter == 3)
            {
                counter = 0;
                aux = Int32.Parse(noLabel.Text) + 1;
                noLabel.Text = "" + aux;
            }
            aux = Int32.Parse(ruleLabel.Text) + 1;
            ruleLabel.Text = "" + aux;
            aux = Int32.Parse(yearLabel.Text) + 1;
            yearLabel.Text = "" + aux;
            new_event();


            if (Int32.Parse(ruleLabel.Text) % 10 == 0 && check!=1)
            {
                decadeCounter++;
                int aux2 = 0;
                aux2 = Int32.Parse(nobilityLabel.Text) + 10;
                nobilityLabel.Text = "" + aux2;
                nobilityChange.Text = "10";
                nobilityChange.ForeColor = Color.Green;
                aux2 = Int32.Parse(commonerLabel.Text) + 10;
                commonerLabel.Text = "" + aux2;
                commonerChange.Text = "10";
                commonerChange.ForeColor = Color.Green;
                aux2 = Int32.Parse(clergyLabel.Text) + 10;
                clergyLabel.Text = "" + aux2;
                clergyChange.Text = "10";
                clergyChange.ForeColor = Color.Green;
                aux2 = Int32.Parse(armyLabel.Text) + 10;
                armyLabel.Text = "" + aux2;
                armyChange.Text = "10";
                armyChange.ForeColor = Color.Green;
                aux2 = Int32.Parse(moneyLabel.Text) + 1000;
                moneyLabel.Text = "" + aux2;
                moneyChange.Text = "1000";
                moneyChange.ForeColor = Color.Green;
                aux2 = Int32.Parse(landLabel.Text) + 20;
                landLabel.Text = "" + aux2;
                landChange.Text = "20";
                landChange.ForeColor = Color.Green;
                aux2 = Int32.Parse(populationLabel.Text) + 200;
                populationLabel.Text = "" + aux2;
                populationChange.Text = "200";
                populationChange.ForeColor = Color.Green;
                MessageBox.Show("You survived 10 years and people trust your rule");

                if (decadeCounter > 5)
                {
                    kingPicture.Image = The_King_s_Gambit.Properties.Resources.TheEmperor;
                }
                else if (decadeCounter > 2)
                {
                    kingPicture.Image= The_King_s_Gambit.Properties.Resources.TheKing;
                }
                else if (decadeCounter > 0)
                {
                    resignButton.Enabled = true;
                }

            }
            if (Int32.Parse(moneyLabel.Text) < 5000)
            {
                kingdomPicture.Image = The_King_s_Gambit.Properties.Resources.TheMoon;
            }
            else if(Int32.Parse(moneyLabel.Text)<10000)
            {
                kingdomPicture.Image = The_King_s_Gambit.Properties.Resources.TheNature;
            }
            else
            {
                kingdomPicture.Image = The_King_s_Gambit.Properties.Resources.AiTarot3;
            }

            if (check == 1)
            {
                MessageBox.Show("You are deposed for badly managing your kingdom in a very violent uprising\n\nYou ruled for "+ruleLabel.Text+" years\nYour kingdom is now in ruin and your people's fate is unknown");
                button1.Enabled = false;
                button2.Enabled = false;
                resignButton.Enabled = false;
                kingdomPicture.Image = The_King_s_Gambit.Properties.Resources.TheTower;
                kingPicture.Image = The_King_s_Gambit.Properties.Resources.TheDeath;
                quitButton.Visible = true;
                
            }
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Int32.Parse(noLabel.Text) <= 0)
            {

            }
            else
            {
                nobilityChange.Text = "";
                clergyChange.Text = "";
                commonerChange.Text = "";
                armyChange.Text = "";
                landChange.Text = "";
                moneyChange.Text = "";
                populationChange.Text = "";
                
                
                int aux = Int32.Parse(noLabel.Text) - 1;
                noLabel.Text =""+ aux;
                new_event();
            }
            
        }

        private void resignButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            int money = Int32.Parse(moneyLabel.Text);
            int army = Int32.Parse(armyLabel.Text);
            int land = Int32.Parse(landLabel.Text);
            int population = Int32.Parse(populationLabel.Text);
            int nobility = Int32.Parse(nobilityLabel.Text);
            int clergy = Int32.Parse(clergyLabel.Text);
            int commons = Int32.Parse(commonerLabel.Text);
            int rule = Int32.Parse(ruleLabel.Text);
            EndingForm ef = new EndingForm(nobility,clergy,commons,money,army,land,population,rule);
            ef.ShowDialog();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
