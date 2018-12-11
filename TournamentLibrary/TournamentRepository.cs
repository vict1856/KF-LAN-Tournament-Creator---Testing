using System;
using System.Collections.Generic;

namespace TournamentLibrary
{
    public class TournamentRepository
    {
        public List<Tournament> tournaments = new List<Tournament>();
        public List<Team> teams = new List<Team>();

        public void AddTournament(Tournament tournament)
        {
            tournaments.Add(tournament);
        }
    }
}
