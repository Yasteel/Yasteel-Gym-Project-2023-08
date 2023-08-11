﻿namespace Models.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Members
    {
        [Key]
        [Required]
        [Column("pkMemberId")]
        public int MemberId { get; set; }

        [Display(Name = "ID Number")]
        [Required]
        [StringLength(13)]

        public string IdNumber { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [MaxLength(50)]
        public string? Surname { get; set; }

        [MaxLength(20)]
        public string? Gender { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public double Height { get; set; }

        [Display(Name = "Contact #")]
        [MaxLength(20)]
        public string? ContactNumber { get; set; }

        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        [Required]
        [Column("fkMembershipType")]
        public EnumMembershipType MembershipType { get; set; }


    }
}