namespace mcpservercsharpconsole.Database;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("reviews")]
public class Review
{
    [Key]
    [Column("review_id")]
    public int ReviewId { get; set; }

    [Required]
    [Column("book_id")]
    public int BookId { get; set; }

    [Required]
    [Column("member_id")]
    public int MemberId { get; set; }

    [Required]
    [Range(1, 5)]
    [Column("rating")]
    public int Rating { get; set; }

    [Column("review_text")]
    public string ReviewText { get; set; }

    [Required]
    [Column("review_date")]
    public DateTime ReviewDate { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member Member { get; set; }
}
