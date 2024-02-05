using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_King_s_Gambit
{
    public partial class EndingForm : Form
    {
        private int nobility;
        private int clergy;
        private int commons;
        private int money;
        private int land;
        private int population;
        private int army;
        private int rule;
        public EndingForm(int nobility,int clergy,int commons,int money,int army,int land,int population,int rule)
        {
            this.nobility = nobility;
            this.clergy = clergy;
            this.commons = commons;
            this.money= money;
            this.army = army;
            this.land = land;
            this.population = population;
            this.rule = rule;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EndingForm_Load(object sender, EventArgs e)
        {
            if (nobility > 200)
            {
                nobilityBox.Image = The_King_s_Gambit.Properties.Resources.TheChariot;
            }
            if (clergy > 200)
            {
                clergyBox.Image = The_King_s_Gambit.Properties.Resources.ThePriestess;
            }
            if(commons > 200)
            {
                commonerBox.Image = The_King_s_Gambit.Properties.Resources.TheJustice;
            }
            if (money > 20000)
            {
                moneyBox.Image = The_King_s_Gambit.Properties.Resources.TheWheel;
            }
            if (army > 200)
            {
                armyBox.Image = The_King_s_Gambit.Properties.Resources.TheStrength;
            }
            if (land > 1000)
            {
                landBox.Image = The_King_s_Gambit.Properties.Resources.TheNature;
            }
            if (population > 5000)
            {
                populationBox.Image = The_King_s_Gambit.Properties.Resources.TheStrength;
            }
            if (rule > 59)
            {
                kingBox.Image = The_King_s_Gambit.Properties.Resources.TheEmperor;
            }
            else if (rule > 29)
            {
                kingBox.Image = The_King_s_Gambit.Properties.Resources.TheKing;
            }
            rulerLabel.Text = "You ruled for " + rule + " years!";

        }
    }
}
