using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Model
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int PublicationYear { get; set; }

    }
}
