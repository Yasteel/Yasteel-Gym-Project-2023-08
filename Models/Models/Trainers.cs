using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Models
{
    public enum TrainerClass
    {
        A = 1, 
        B = 2,
        C = 3
    }


    public class Trainers
    {
        [Key]
        [Column("pkTrainerId")]
        public int TrainerId { get; set; }

        public string IdNumber { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string ContactNumber { get; set; }

        public TrainerClass TrainerClass { get; set; }

        public double Salary { get; set; }
    }
}
