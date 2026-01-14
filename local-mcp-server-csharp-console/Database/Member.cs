namespace mcpservercsharpconsole.Database;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("members")]
public class Member
{
    [Key]
    [Column("member_id")]
    public int MemberId { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("first_name")]
    public string FirstName { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("last_name")]
    public string LastName { get; set; }

    [Required]
    [MaxLength(100)]
    [Column("email")]
    public string Email { get; set; }

    [MaxLength(20)]
    [Column("phone")]
    public string Phone { get; set; }

    [Required]
    [Column("membership_date")]
    public DateTime MembershipDate { get; set; }

    [MaxLength(20)]
    [Column("membership_status")]
    public string MembershipStatus { get; set; } = "active";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navigation properties
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    [NotMapped]
    public string FullName => $"{FirstName} {LastName}";
}
