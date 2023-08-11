namespace Models.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    public class MemberHrRecord
    {
        [Key]
        [Column("pkHrRecordId")]
        public int HrRecordId { get; set; }

        [Column("fkMemberId")]
        [ForeignKey(nameof(this.Member))]
        public int MemberId { get; set; }

        Members Member { get; set; }

        public double HRmax { get; set; }

        public double HRrest { get; set; }

        public double OTWOmax { get; set; }
    }
}
