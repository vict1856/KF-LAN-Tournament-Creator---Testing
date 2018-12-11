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
                        AddTeam();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
            while (running == true);

            void AddTeam()
            {
                Console.Clear();
                Console.WriteLine("Choose teams to add:");
                Console.WriteLine();
                control.ShowTeams();

                bool zero = false;

                do
                {
                    string input = Console.ReadLine();

                    if (input == "0")
                    {
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
        }

        private void ShowTournamentMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add team to tournament");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        private string GetUserChoice()  //Gets string from console
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option");
            return Console.ReadLine();
        }
    }
}
