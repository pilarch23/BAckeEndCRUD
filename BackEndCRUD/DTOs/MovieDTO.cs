namespace BackEndCRUD.DTOs
{
    public class MovieDTO
    {
        public int IdMovies { get; set; }

        public string? MovieName { get; set; }

        public string? Gender { get; set; }

        public string? Duration { get; set; }

        public int? DirectorKey { get; set; }

        public string? Director { get; set; }
    }
}
