using marking_test_task.Config;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marking_test_task.Models
{
    public class Bottle
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; private set; }
        public int? BoxId { get; set; }

        [ForeignKey("BoxId")]
        public Box Boxses { get; set; }

        public Bottle SetCode(string gtin)
        {
            Code = CodesRule.RuleForBottles(gtin);
            return this;
        }
    }
}
