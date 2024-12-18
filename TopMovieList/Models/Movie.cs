using static TopMovieList.Enums;

namespace TopMovieList.Models
{
    internal class Movie
    {
        internal int Id { get; set; }
        internal string Title { get; set; }
        internal Genre Genre { get; set; }
        internal MovieStatus Status { get; set; }

        internal DateTime Length { get; set; }

        internal Movie() { }



    }
}
