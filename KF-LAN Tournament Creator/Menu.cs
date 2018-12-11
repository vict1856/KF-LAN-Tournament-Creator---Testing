using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentLibrary;

namespace KF_LAN_Tournament_Creator
{
    public class Menu
    {
        private MenuController control = new MenuController();   //Set up instance of MenuController

        //----------------------------------------------------------STARTMENU----------------------------------------------------------
        public void ShowMenu()  //Shows the startmenu
        {
            bool running = true;

            do  //Loops forever until program is exited
            {
                ShowOptions();  //Console.WriteLine that shows all options
                string choice = GetUserChoice();    //Gets a string from the console

                switch (choice) //Matches the string gotten from console with one of our cases
                {
                    case "0":
                        running = false;
                        break;
                    case "1":
                        CreateTournament();
                        break;
                    case "2":
                        ShowTournaments();
                        break;
                    case "3":
                        CreateTeam();
                        break;
                    case "4":
                        ShowTeams();
                        break;
                    case "5":
                        OpenTournament();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }

            }
            while (running == true);
        }

        private void ShowOptions()      //Console.WriteLine that shows all options
        {
            Console.WriteLine("KF-LAN Tournament Creator");
            Console.WriteLine();
            Console.WriteLine("1. Create Tournament");
            Console.WriteLine("2. Show all Tournaments");
            Console.WriteLine("3. Create Team");
            Console.WriteLine("4. Show all Teams");
            Console.WriteLine("5. Open Tournament");
            Console.WriteLine("0. Exit");
        }

        private string GetUserChoice()  //Gets string from console
        {
            Console.WriteLine();
            Console.WriteLine("Choose an option");
            return Console.ReadLine();
        }

        private void CreateTournament() //Creates tournament using name and game. Calls the CreateTournament method in MenuController
        {
            Console.Clear();
            Console.WriteLine("Tournament Name:");
            string tournamentName = Console.ReadLine();
            Console.WriteLine("Tournament Game:");
            string tournamentGame = Console.ReadLine();
            Console.Clear();

            control.CreateTournament(tournamentName, tournamentGame);
        }

        private void ShowTournaments()  //Shows all tournaments. Calls the ShowTournaments method in MenuController
        {
            Console.Clear();
            Console.WriteLine("Tournaments:");
            Console.WriteLine();

            control.ShowTournaments();

            Console.WriteLine();
        }

        private void CreateTeam()       //Creates team using name. Calls the CreateTeam function in MenuController
        {
            Console.Clear();
            Console.WriteLine("Team Name:");
            string teamName = Console.ReadLine();

            control.CreateTeam(teamName);

            Console.Clear();
        }

        private void ShowTeams()        //Shows all teams. Calls the ShowTeams function in MenuController
        {
            Console.Clear();
            Console.WriteLine("Teams:");
            Console.WriteLine();

            control.ShowTeams();

            Console.WriteLine();
        }

        private void OpenTournament()   //Opens up the tournament menu for a specific tournament
        {
            Console.Clear();
            Console.WriteLine("Choose Tournament:");
            Console.WriteLine();
            ShowTournaments();
            Console.WriteLine();

            Tournament tournament = control.OpenTournament(int.Parse(Console.ReadLine()));

            Console.Clear();

            control.ShowTournamentMenu(tournament, control);
        }
    }
}
