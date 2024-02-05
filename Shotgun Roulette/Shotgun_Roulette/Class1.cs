using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{

    internal class Player
    {
        private string name;
        private int wins;
        private int loses;
        private bool elimination;
        public Player(string name)
        {
            this.name = name;
            this.wins = 0;
            this.loses = 0;
            this.elimination = false;
        }

        public void add_loss()
        {
            this.loses = this.loses + 1;
        }

        public void add_victory()
        {
            this.wins++;
        }

        public void check_elimination()
        {
            if (this.loses >= 2)
            {
                this.elimination = true;
            }
        }

        public string get_name()
        {
            return this.name;
        }

        public int get_loses()
        {
            return this.loses;
        }

        public int get_wins()
        {
            return this.wins;
        }

        public bool get_elimination_status()
        {
            return this.elimination;
        }

    }
}
