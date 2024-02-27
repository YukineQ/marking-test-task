using marking_test_task.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marking_test_task.Models
{
    public class Box
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }

        public int? PalleteId { get; set; }

        [ForeignKey("PalleteId")]
        public Pallete Pallete { get; set; }

        public List<Bottle> Bottles { get; private set; } = new();

        public Box SetCode(string gtin, int productAmount, int id)
        {
            Code = CodesRule.RuleForBoxes(gtin, productAmount, id);
            return this;
        }

        public Box AddBottles(List<Bottle> bottles)
        {
            Bottles = bottles;
            return this;
        }
    }
}
