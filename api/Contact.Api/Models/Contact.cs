using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contact.Api.Models
{
    public class Contact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ContactId { get; set; }

        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Email { get; set; }
    }
}