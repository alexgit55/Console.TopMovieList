namespace TopMovieList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var movieController = new MovieController();
            movieController.CreateDatabase();

            //UserInterface.DisplayMainMenu();
        }
    }
}
