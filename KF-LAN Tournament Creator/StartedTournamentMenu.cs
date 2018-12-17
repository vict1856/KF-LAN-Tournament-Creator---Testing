using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary;

namespace KF_LAN_Tournament_Creator
{
    public class StartedTournamentMenu
    {
        public MenuController control;

        //----------------------------------------------------------------------------------------------------

        public void ShowStartedTournamentMenu(Tournament tournament, MenuController control)
        {
            this.control = control;

            Console.WriteLine("Tournament: " + tournament.Name);
            bool running = true;
            Tournament startedTournament = tournament;

            do
            {
                ShowStartedTournamentMenuOptions();
                string choice = GetUserChoice();

                switch (choice)
                {
                    case "0":
                        Console.Clear();
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            while (running == true);
        }

        //----------------------------------------------------------------------------------------------------

        private string GetUserChoice()  //Gets string from console
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option");
            return Console.ReadLine();
        }

        //----------------------------------------------------------------------------------------------------

        private void ShowStartedTournamentMenuOptions()
        {
            Console.WriteLine();
            Console.WriteLine("1. Add team to tournament");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        //----------------------------------------------------------------------------------------------------


    }
}
