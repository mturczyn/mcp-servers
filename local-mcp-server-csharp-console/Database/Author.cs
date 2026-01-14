namespace mcpservercsharpconsole.Database;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// ==================== ENTITY MODELS ====================

[Table("authors")]
public class Author
{
    [Key]
    [Column("author_id")]
    public int AuthorId { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("first_name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("last_name")]
    public string LastName { get; set; }

    [Column("birth_year")]
    public int? BirthYear { get; set; }

    [MaxLength(50)]
    [Column("nationality")]
    public string Nationality { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation property
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}
