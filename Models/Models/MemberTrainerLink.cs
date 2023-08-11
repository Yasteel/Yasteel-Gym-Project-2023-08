using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public class MemberTrainerLink
    {
        [Key]
        [Column("pkLinkId")]
        public int LinkId { get; set; }

        [Column("fkMemberId")]
        [ForeignKey(nameof(this.Member))]
        public int MemberId { get; set; }

        public Members Member { get; set; }


        [Column("fkTrainerId")]
        [ForeignKey(nameof(this.Trainer))]
        public int TrainerId { get; set; }

        public Trainers Trainer { get; set; }
    }
}
