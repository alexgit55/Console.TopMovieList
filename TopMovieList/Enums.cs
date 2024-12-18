using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TopMovieList
{
    internal class Enums
    {
        internal enum Genre
        {
            Action,
            Adventure,
            Animation,
            Comedy,
            Crime,
            Drama,
            Fantasy,
            Historical,
            Horror,
            Mystery,
            Romance,
            ScienceFiction,
            Thriller,
            Western
        }

        internal enum MainMenuOptions
        {
            ViewFullMovieList,
            ViewPartialMovieList,
            UpdateMovieStatus,
            AddMovieToList,
            Exit
        }

        internal enum MovieStatus
        {
            [Display(Name = "Not Watched")]
            [Description("Movies that I have not watched")]
            NotWatched,

            [Display(Name = "Need Refresh")]
            [Description("Movies that I need to watch again for a refresh")]
            NeedRefresh,

            [Display(Name = "Watched")]
            [Description("Movies that I considered completed")]
            Watched
        }
    }
}
