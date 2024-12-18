using Spectre.Console;
using static TopMovieList.Enums;

namespace TopMovieList
{
    internal class UserInterface
    {
        internal static void DisplayMainMenu()
        {
            var isMenuRunning = true;
            string menuMessage= "Press any key to go back to the main menu";

            while (isMenuRunning)
            {
                var userChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<Enums.MainMenuOptions>()
                        .Title("Main Menu")
                        .HighlightStyle("green")
                        .AddChoices(
                            MainMenuOptions.ViewFullMovieList, 
                            MainMenuOptions.ViewPartialMovieList, 
                            MainMenuOptions.UpdateMovieStatus, 
                            MainMenuOptions.AddMovieToList,
                            MainMenuOptions.Exit
                            )
                );
            }

        }
    }
}
