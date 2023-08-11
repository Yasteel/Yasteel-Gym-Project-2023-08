namespace Models.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class MemberBmiRecord
    {
        [Key]
        [Column("pkBmiRecordId")]
        public int BmiRecordId { get; set; }

        [Column("fkMemberId")]
        [ForeignKey(nameof(this.Member))]
        public int MemberId { get; set; }

        Members Member { get; set; }

        public double Weight { get; set; }

        public double BMI { get; set;}
    }
}
