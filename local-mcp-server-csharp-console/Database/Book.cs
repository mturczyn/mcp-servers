namespace mcpservercsharpconsole.Database;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("books")]
public class Book
{
    [Key]
    [Column("book_id")]
    public int BookId { get; set; }

    [Required]
    [MaxLength(200)]
    [Column("title")]
    public string Title { get; set; }

    [Required]
    [Column("author_id")]
    public int AuthorId { get; set; }

    [MaxLength(13)]
    [Column("isbn")]
    public string Isbn { get; set; }

    [Column("publication_year")]
    public int? PublicationYear { get; set; }

    [MaxLength(50)]
    [Column("genre")]
    public string Genre { get; set; }

    [Column("pages")]
    public int? Pages { get; set; }

    [Column("available_copies")]
    public int AvailableCopies { get; set; } = 0;

    [Column("total_copies")]
    public int TotalCopies { get; set; } = 0;

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("AuthorId")]
    public virtual Author Author { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
