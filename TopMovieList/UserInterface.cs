using Spectre.Console;
using TopMovieList.Models;
using static TopMovieList.Enums;

namespace TopMovieList
{
    internal class UserInterface
    {
        internal static void DisplayMainMenu()
        {
            var isMenuRunning = true;
            string menuMessage= "Press any key to go back to the main menu";
            MovieController movieController = new();

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

                switch (userChoice)
                {
                    case MainMenuOptions.ViewFullMovieList:
                        var movies = movieController.GetMovies("SELECT * FROM movies");
                        DisplayMovieList(movies);
                        break;
                    case MainMenuOptions.ViewPartialMovieList:
                        //DisplayPartialMovieList();
                        break;
                    case MainMenuOptions.UpdateMovieStatus:
                        //UpdateMovieStatus();
                        break;
                    case MainMenuOptions.AddMovieToList:
                        var movieToAdd=GetMovieInput();
                        movieController.AddMovie(movieToAdd);
                        break;
                    case MainMenuOptions.Exit:
                        isMenuRunning = false;
                        menuMessage = "Goodbye!";
                        break;
                }

                AnsiConsole.MarkupLine(menuMessage);
                Console.ReadKey();
                Console.Clear();
            }

        }

        private static Movie GetMovieInput()
        {
            var movieTitle = AnsiConsole.Ask<string>("Enter the title of the movie: ");
            var movieGenre = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.Genre>()
                .Title("Select the genre(s) of the movie")
                .HighlightStyle("green")
                .MoreChoicesText("Scroll down to see more genres")
                .AddChoices(
                    Genre.Action,
                    Genre.Adventure,
                    Genre.Animation,
                    Genre.Comedy,
                    Genre.Crime,
                    Genre.Drama,
                    Genre.Fantasy,
                    Genre.Historical,
                    Genre.Horror,
                    Genre.Mystery,
                    Genre.Romance,
                    Genre.ScienceFiction,
                    Genre.Thriller,
                    Genre.Western
                ));

            var movieStatus = AnsiConsole.Prompt(
                new SelectionPrompt<Enums.MovieStatus>()
                .Title("Select the status of the movie")
                .HighlightStyle("green")
                .AddChoices(
                    MovieStatus.NotWatched,
                    MovieStatus.NeedRefresh,
                    MovieStatus.Watched
                ));

            var movieLength = GetTime();

            return new Movie()
            {
                Title = movieTitle,
                Genre = movieGenre,
                Status = movieStatus,
                Length = movieLength
            };


        }

        private static string GetTime()
        {
            var lengthInput = AnsiConsole.Ask<string>("Enter the length of the movie in the format HH:MM: ");

            while(!DateTime.TryParseExact(lengthInput, "HH:mm", null, System.Globalization.DateTimeStyles.None, out _))
            {
                lengthInput = AnsiConsole.Ask<string>("Invalid input. Please enter the length of the movie in the format HH:MM: ");
            }

            return lengthInput;
        }

        private static void DisplayMovieList(List<Movie> Movies)
        {
            var table = new Table();
            table.AddColumn("Title");
            table.AddColumn("Genre");
            table.AddColumn("Status");
            table.AddColumn("Length");

            table.Border(TableBorder.Rounded);

            foreach (var movie in Movies)
            {
                table.AddRow(movie.GetColumsArray());
            }

            AnsiConsole.Write(table);
        }
    }
}
