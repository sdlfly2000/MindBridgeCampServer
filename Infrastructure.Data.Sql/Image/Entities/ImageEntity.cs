using System;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Data.Sql.Image.Entities
{
    public class ImageEntity
    {
        [Key]
        public string imageId { get; set; }

        public string extension { get; set; }

        public string createdBy { get; set; }

        public DateTime createdOn { get; set; }

        public int status { get; set; }
    }
}
