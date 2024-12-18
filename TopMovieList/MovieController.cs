using Microsoft.Data.Sqlite;
using TopMovieList.Models;
using static TopMovieList.Enums;


namespace TopMovieList
{
    internal class MovieController
    {
        private string ConnectionString { get; } = "Data Source=TopMovies.db;";

        internal void CreateDatabase()
        {
            try
            {
                using var connection = new SqliteConnection(ConnectionString);
                connection.Open();
                var createTableCommand = connection.CreateCommand();
                createTableCommand.CommandText = "CREATE TABLE IF NOT EXISTS Movies (Id INTEGER PRIMARY KEY AUTOINCREMENT, Title TEXT NOT NULL, Genre TEXT, Status TEXT NOT NULL, Length TEXT)";
                createTableCommand.ExecuteNonQuery();
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        internal List<Movie> GetMovies()
        {
            var movies = new List<Movie>();

            try
            {
                using var connection = new SqliteConnection(ConnectionString);
                connection.Open();
                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = "SELECT * FROM Movies";
                using var reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    var movie = new Movie
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Genre = Enum.Parse<Genre>(reader.GetString(2)),
                        Status = Enum.Parse<MovieStatus>(reader.GetString(3)),
                        Length = DateTime.Parse(reader.GetString(4))
                    };
                    movies.Add(movie);
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return movies;
        }
    }
}
