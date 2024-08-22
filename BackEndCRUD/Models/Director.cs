using System;
using System.Collections.Generic;

namespace BackEndCRUD.Models;

public partial class Director
{
    public int IdDirector { get; set; }

    public string? DirectorName { get; set; }

    public int? Age { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Movie> Movies { get; } = new List<Movie>();
}