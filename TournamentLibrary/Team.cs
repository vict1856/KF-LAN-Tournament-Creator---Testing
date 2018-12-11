using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class Team
    {
        List<string> players = new List<string>();
        public string teamName;

        public string TeamName
        {
            get
            {
                return teamName;
            }
            set
            {
                teamName = value;
            }
        }
    }
}
