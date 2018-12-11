using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary;

namespace KF_LAN_Tournament_Creator
{
    public class MenuController
    {
        private TournamentRepository tournamentRepo = new TournamentRepository();
        private TeamRepository teamRepo = new TeamRepository();
        public TournamentMenu tournamentMenu = new TournamentMenu();

        public void CreateTournament(string tournamentName, string tournamentGame)
        {
            Tournament tournament = new Tournament();

            tournament.Name = tournamentName;

            tournamentRepo.AddTournament(tournament);
        }

        public void ShowTournaments()
        {
            for (int i = 0; i < tournamentRepo.tournaments.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + tournamentRepo.tournaments[i].Name);
            }
        }

        public void ShowTeams()
        {
            for (int i = 0; i < teamRepo.teams.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + teamRepo.teams[i].teamName);
            }
        }

        public void CreateTeam(string teamName)
        {
            Team team = new Team();

            team.TeamName = teamName;

            teamRepo.AddTeam(team);
        }

        public Tournament OpenTournament(int tournament)
        {
            return tournamentRepo.tournaments[tournament - 1];
        }

        public Team GetTeam(int team)
        {
            return teamRepo.teams[team - 1];
        }

        public void ShowTournamentMenu(Tournament tournament, MenuController control)
        {
            tournamentMenu.ShowTournamentMenu(tournament, control);
        }
    }
}
