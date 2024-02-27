using System.ComponentModel.DataAnnotations;

namespace marking_test_task.Models
{
    public class Mission
    {
        [Key]
        public int Id { get; set; }
        public int MissionId { get; set; }
        public string Gtin { get; set; }
        public int BoxCapacity { get; set; }
        public int PalleteCapacity { get; set; }
        public List<Pallete> Palletes { get; private set; } = [];
        public Mission SetPalletes(List<Pallete> palletes)
        {
            Palletes = palletes;
            return this;
        }
    }
}
