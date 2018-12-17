using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class SubRound
    {
        private List<Match> matches = new List<Match>();

        public List<Match> Matches
        {
            get
            {
                return matches;
            }
        }
    }
}
