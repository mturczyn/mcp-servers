namespace mcpservercsharpconsole.Database;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("loans")]
public class Loan
{
    [Key]
    [Column("loan_id")]
    public int LoanId { get; set; }

    [Required]
    [Column("book_id")]
    public int BookId { get; set; }

    [Required]
    [Column("member_id")]
    public int MemberId { get; set; }

    [Required]
    [Column("loan_date")]
    public DateTime LoanDate { get; set; }

    [Required]
    [Column("due_date")]
    public DateTime DueDate { get; set; }

    [Column("return_date")]
    public DateTime? ReturnDate { get; set; }

    [MaxLength(20)]
    [Column("status")]
    public string Status { get; set; } = "active";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    [ForeignKey("BookId")]
    public virtual Book Book { get; set; }

    [ForeignKey("MemberId")]
    public virtual Member Member { get; set; }

    [NotMapped]
    public bool IsOverdue => Status == "active" && DateTime.Now.Date > DueDate.Date;

    [NotMapped]
    public int DaysOverdue => IsOverdue ? (DateTime.Now.Date - DueDate.Date).Days : 0;
}
