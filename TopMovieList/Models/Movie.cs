using Microsoft.Data.Sqlite;
using static TopMovieList.Enums;

namespace TopMovieList.Models
{
    internal class Movie
    {
        internal int Id { get; }
        internal string Title { get; set; }
        internal Genre Genre { get; set; }
        internal MovieStatus Status { get; set; }

        internal string Length { get; set; }

        internal Movie() { }
        internal Movie(int id) 
        {
            Id = id;
        }

        internal void AddParameters(SqliteCommand command)
        {
            command.Parameters.AddWithValue("@Title", Title);
            command.Parameters.AddWithValue("@Genre", Genre.ToString());
            command.Parameters.AddWithValue("@Status", Status.ToString());
            command.Parameters.AddWithValue("@Length", Length.ToString());
        }

        internal string[] GetColumsArray()
        {
            return new string[] { Title, Genre.ToString(), Status.ToString(), Length };
        }

        internal string GetInsertQuery()
        {
            return $@"INSERT INTO Movies (Title, Genre, Status, Length) VALUES (@Title, @Genre, @Status, @Length)";
        }



    }
}
