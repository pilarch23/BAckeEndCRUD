using System;
using System.Collections.Generic;

namespace BackEndCRUD.Models;

public partial class Movie
{
    public int IdMovies { get; set; }

    public string? MovieName { get; set; }

    public string? Gender { get; set; }

    public TimeSpan? Duration { get; set; }

    public int? DirectorKey { get; set; }

    public virtual Director? DirectorKeyNavigation { get; set; }
}
