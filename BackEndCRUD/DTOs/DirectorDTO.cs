using BackEndCRUD.Models;

namespace BackEndCRUD.DTOs
{
    public class DirectorDTO
    {
        public int IdDirector { get; set; }

        public string? DirectorName { get; set; }

        public int? Age { get; set; }

        public bool? Active { get; set; }
    }
}
