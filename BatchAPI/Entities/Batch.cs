using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BatchAPI.Entities
{
    [Table("BatchDetails")]
    public class Batch // Update this as per the json 
    {
        [Key]
        public int UId { get; set; }
        public string? BatchId { get; set; }
        public string? BusinessUnit { get;set; }
        public string? ExpiryDate { get; set; }

        public Files? Files { get; set; }
        public string? Status { get; set; }
        public string? ReadUsers { get; set; }
        public string? ReadGroups { get; set;}
        public string? KeyAttribute { get; set;}
        public string? ValueAttribute { get; set;}
    }
    public class Files
    {
        [Key]
        public int Id { get; set; }
        public int UId { get; set; }
        public string? FileName { get; set; }
        public Byte[]? Filedata { get; set; }
        public string? FileType { get; set; }

    }
}
 