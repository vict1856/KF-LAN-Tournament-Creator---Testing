using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class TeamRepository
    {
        public List<Team> teams = new List<Team>();

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }
    }
}
