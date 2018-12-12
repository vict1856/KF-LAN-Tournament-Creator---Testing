using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class Match
    {
        private Team teamOne;
        private Team teamTwo;

        private Team winner;

        public Team TeamOne
        {
            get
            {
                return teamOne;
            }
            set
            {
                teamOne = value;
            }
        }

        public Team TeamTwo
        {
            get
            {
                return teamTwo;
            }
            set
            {
                teamTwo = value;
            }
        }

        public Team Winner
        {
            get
            {
                return winner;
            }
            set
            {
                winner = value;
            }
        }
    }
}
