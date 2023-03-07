using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment3.Models
{
    public class Movie   {
        public int Id { get; set; }
        public string? Title { get; set; }

        [Url]
        public string? IMDBurl { get; set; }
        public string? Genre { get; set; }
        public string? Year { get; set; }
        public byte[]? Photo { get; set; }

        [ForeignKey("Actor")]
        public int? ActorId { get; set; }

    }
}
