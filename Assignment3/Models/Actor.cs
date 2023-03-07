using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment3.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Gender { get; set; }
        public int ? Age { get; set; }

        [Url]
        public string? IMDBurl { get; set; }
        public byte[]? Photo { get; set; }

        [ForeignKey("Movie")]
        public int? MovieId { get; set; }
    }
}
