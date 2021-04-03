using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.Image.Entities
{
    public class ImageEntity
    {
        [Key]
        public string imageId { get; set; }

        public string imageRef { get; set; }

        public string imageName { get; set; }

        public string imageDirectory { get; set; }

        public int imageStatus { get; set; }
    }
}
