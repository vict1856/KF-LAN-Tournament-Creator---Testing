using System;
using System.Collections.Generic;
using System.Text;

namespace TournamentLibrary
{
    public class Tournament
    {
        private string name;
        private bool isStarted = false;
        List<Team> teams = new List<Team>();
        private List<Round> rounds = new List<Round>();

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public bool IsStarted
        {
            get
            {
                return isStarted;
            }
            set
            {
                isStarted = value;
            }
        }

        public void AddTeam(Team team)
        {
            teams.Add(team);
        }

        public List<Team> Teams
        {
            get
            {
                return teams;
            }
        }

        public List<Round> Rounds
        {
            get
            {
                return rounds;
            }
        }

        public void AddRound(Round round)
        {
            rounds.Add(round);
        }
    }
}
