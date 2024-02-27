using marking_test_task.Config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marking_test_task.Models
{
    public class Pallete
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; private set; }
        public int? MissionId { get; set; }

        [ForeignKey("MissionId")]
        public Mission Mission { get; set; }
        public List<Box> Boxes { get; private set; } = [];
        public Pallete SetCode(string gtin, int productAmount, int id)
        {
            Code = CodesRule.RuleForPalletes(gtin, productAmount, id);
            return this;
        }
        public Pallete SetBoxes(List<Box> boxes)
        {
            Boxes = boxes;
            return this;
        }
    }
}
