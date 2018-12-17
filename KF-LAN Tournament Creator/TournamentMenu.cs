using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary;

namespace KF_LAN_Tournament_Creator
{
    public class TournamentMenu
    {
        public MenuController control;

        //----------------------------------------------------------------------------------------------------

        public void ShowTournamentMenu(Tournament tournament, MenuController control)
        {
            this.control = control;

            Console.WriteLine("Tournament: " + tournament.Name);
            bool running = true;
            Tournament openTournament = tournament;

            do
            {
                ShowTournamentMenuOptions();
                string choice = GetUserChoice();

                switch (choice)
                {
                    case "0":
                        Console.Clear();
                        running = false;
                        break;
                    case "1":
                        AddTeam(tournament);
                        break;
                    case "2":
                        ShowAddedTeams(tournament);
                        break;
                    case "3":
                        StartTournament(tournament);
                        break;
                    case "4":
                        ShowGroup(tournament);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            while (running == true);
        }

        //----------------------------------------------------------------------------------------------------

        void ShowAddedTeams(Tournament tournament)
        {
            for (int i = 0; i < tournament.Teams.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + tournament.Teams[i].TeamName);
            }
        }

        //----------------------------------------------------------------------------------------------------

        void AddTeam(Tournament tournament)
        {
            bool zero = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Current lineup:");

                ShowAddedTeams(tournament);

                Console.WriteLine();
                Console.WriteLine("Choose teams to add:");
                Console.WriteLine();
                control.ShowTeams();

                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.Clear();
                    zero = true;
                }
                else
                {
                    if (int.TryParse(input, out int parsedInput))
                    {
                        control.GetTeam(int.Parse(input));
                        Team team = control.GetTeam(parsedInput);
                        tournament.AddTeam(team);
                    }
                    else
                    {
                        Console.WriteLine("Invalid option");
                    }
                }
            }
            while (zero == false);
        }

        //----------------------------------------------------------------------------------------------------

        private void StartTournament(Tournament tournament)
        {
            control.StartTournament(tournament, control);
        }

        //----------------------------------------------------------------------------------------------------

        private void ShowTournamentMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add team to tournament");
            Console.WriteLine("2. Show added teams");
            Console.WriteLine("3. Start Tournament");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        //----------------------------------------------------------------------------------------------------

        private void ShowGroup(Tournament tournament)
        {
            Console.Clear();
            Console.WriteLine("Choose Group");
            Console.WriteLine();

            string input = Console.ReadLine();
            int parsedInput = int.Parse(input);

            Console.Clear();
            Console.WriteLine("Teams:");
            Console.WriteLine();

            foreach (Team team in tournament.Rounds[0].Groups[parsedInput - 1].Teams)
            {
                Console.WriteLine(team.TeamName);
            }

            Console.WriteLine();
        }

        //----------------------------------------------------------------------------------------------------

        private string GetUserChoice()  //Gets string from console
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option");
            return Console.ReadLine();
        }
    }
}
