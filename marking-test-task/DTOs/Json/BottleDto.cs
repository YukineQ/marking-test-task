using marking_test_task.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace marking_test_task.DTOs.Json
{
    public class BottleDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
    }
}
