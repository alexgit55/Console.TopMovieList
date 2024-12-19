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

        internal List<Movie> GetMovies(string query)
        {
            var movies = new List<Movie>();

            try
            {
                using var connection = new SqliteConnection(ConnectionString);
                connection.Open();
                var selectCommand = connection.CreateCommand();
                selectCommand.CommandText = $@"{query}";
                using var reader = selectCommand.ExecuteReader();
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var movie = new Movie(id);
                    movie.Title = reader.GetString(1);
                    movie.Genre = Enum.Parse<Genre>(reader.GetString(2));
                    movie.Status = Enum.Parse<MovieStatus>(reader.GetString(3));
                    movie.Length = reader.GetString(4);

                    movies.Add(movie);
                }
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return movies;
        }

        internal void AddMovie(Movie movie)
        {
            try
            {
                using var connection = new SqliteConnection(ConnectionString);
                connection.Open();
                var insertCommand = connection.CreateCommand();
                insertCommand.CommandText = movie.GetInsertQuery();
                movie.AddParameters(insertCommand);
                insertCommand.ExecuteNonQuery();

                Console.WriteLine("Movie added successfully!");
            }
            catch (SqliteException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
