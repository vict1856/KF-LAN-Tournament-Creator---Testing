using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class Group
    {
        private List<Team> teams = new List<Team>();
        private List<SubRound> subRounds = new List<SubRound>();
        private List<Match> matches = new List<Match>();

        public List<Team> Teams
        {
            get
            {
                return teams;
            }
        }


        public List<SubRound> SubRounds
        {
            get
            {
                return subRounds;
            }
        }


        public List<Match> Matches
        {
            get
            {
                return matches;
            }
        }
    }
}
