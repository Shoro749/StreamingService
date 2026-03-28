using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StreamingService.Models
{
    [Table("persons_image")]
    public class PersonImage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("id")]
        public int Id { get; set; }

        [Required, StringLength(256), Column("blob_container")]
        public required string BlobContainer { get; set; }

        [Required, StringLength(512), Column("blob_path")]
        public required string BlobPath { get; set; }

        [Column("person_id")]
        public int? PersonId { get; set; }
        public Person Person { get; set; }
    }
}
