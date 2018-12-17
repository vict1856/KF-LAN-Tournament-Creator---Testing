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
        public StartedTournamentMenu startedTournamentMenu = new StartedTournamentMenu();

        //----------------------------------------------------------------------------------------------------

        public void CreateTournament(string tournamentName, string tournamentGame)
        {
            Tournament tournament = new Tournament();

            tournament.Name = tournamentName;

            tournamentRepo.AddTournament(tournament);
        }

        //----------------------------------------------------------------------------------------------------

        public void ShowTournaments()
        {
            for (int i = 0; i < tournamentRepo.tournaments.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + tournamentRepo.tournaments[i].Name);
            }
        }

        //----------------------------------------------------------------------------------------------------

        public void ShowTeams()
        {
            for (int i = 0; i < teamRepo.teams.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + teamRepo.teams[i].TeamName);
            }
        }

        //----------------------------------------------------------------------------------------------------

        public void CreateTeam(string teamName)
        {
            Team team = new Team();

            team.TeamName = teamName;

            teamRepo.AddTeam(team);
        }

        //----------------------------------------------------------------------------------------------------

        public Tournament OpenTournament(int tournament)
        {
            return tournamentRepo.tournaments[tournament - 1];
        }

        //----------------------------------------------------------------------------------------------------

        public Team GetTeam(int team)
        {
            return teamRepo.teams[team - 1];
        }

        //----------------------------------------------------------------------------------------------------

        public void ShowTournamentMenu(Tournament tournament, MenuController control)
        {
            tournamentMenu.ShowTournamentMenu(tournament, control);
        }

        //----------------------------------------------------------------------------------------------------

        public void StartTournament(Tournament tournament, MenuController controller)
        {
            tournament.IsStarted = true;

            MakeRound(tournament);

            ShowStartedTournamentMenu(tournament, controller);
        }

        //----------------------------------------------------------------------------------------------------

        public void MakeRound(Tournament tournament)
        {
            Round round = new Round();

            tournament.AddRound(round);

            int numberOfGroups = tournament.Teams.Count / 5;    //Calculates how many groups are needed

            if (tournament.Teams.Count % 5 != 0)    //Adds another round if needed
            {
                numberOfGroups++;
            }

            for (int idx = 0; idx < numberOfGroups; idx++)
            {
                Group group = new Group();
                round.Groups.Add(group);

                for (int idx2 = idx; idx2 < tournament.Teams.Count; idx2 += numberOfGroups)
                {
                    group.Teams.Add(tournament.Teams[idx2]);
                }

                MakeMatches(group);

                MakeSubRounds(group);

                foreach(SubRound subRound in group.SubRounds)
                {
                    foreach (Match match in subRound.Matches)
                    {
                        Console.WriteLine(match.TeamOne.TeamName + " vs " + match.TeamTwo.TeamName);
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
            }
        }

        //----------------------------------------------------------------------------------------------------

        private void MakeSubRounds(Group group)
        {
            bool teamUsed = false;

            for (int idx = 0; idx < 2; idx++) //variable need to made
            {
                if (group.Teams.Count != 5)
                {
                    for (int idx3 = 0; idx3 < 3; idx3++)
                    {
                        SubRound subRound = new SubRound();

                        group.SubRounds.Add(subRound);

                        Match currentMatch = group.Matches[idx3];

                        subRound.Matches.Add(currentMatch);

                        foreach (Match match in group.Matches)
                        {
                            if (match.TeamOne == currentMatch.TeamOne || match.TeamOne == currentMatch.TeamTwo || match.TeamTwo == currentMatch.TeamOne || match.TeamTwo == currentMatch.TeamTwo)
                            {
                                teamUsed = true;
                            }

                            if (teamUsed == false)
                            {
                                subRound.Matches.Add(match);
                            }

                            teamUsed = false;
                        }
                    }
                }
                else
                {
                    int start = 7;

                    for (int idx3 = 0; idx3 < 5; idx3++)
                    {
                        SubRound subRound = new SubRound();
                        group.SubRounds.Add(subRound);

                        subRound.Matches.Add(group.Matches[idx3]);

                        if (idx3 % 2 == 0)
                        {
                            start += idx3;
                            subRound.Matches.Add(group.Matches[start]);
                        }
                        else
                        {
                            start -= idx3;
                            subRound.Matches.Add(group.Matches[start]);
                        }
                    }
                }
            }
        }

        //----------------------------------------------------------------------------------------------------

        private void MakeMatches(Group group)
        {

        }

        //----------------------------------------------------------------------------------------------------

        public void ShowStartedTournamentMenu(Tournament tournament, MenuController control)
        {
            tournamentMenu.ShowTournamentMenu(tournament, control);
        }
    }
}
