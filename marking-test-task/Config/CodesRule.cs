using marking_test_task.Helpers.Faker;

namespace marking_test_task.Config
{
    public static class CodesRule
    {
        private readonly static FakerBase faker = new FakerBase();

        public static string RuleForBottles(string gtin)
        {
            return $"01{gtin}21{faker.String.Alpha(18)}";
        }

        public static string RuleForBoxes(string gtin, int productAmount, int id)
        {
           return $"01{gtin}37{productAmount}21{id}";
        }

        public static string RuleForPalletes(string gtin, int productAmount, int id)
        {
            return $"01{gtin}37{productAmount}{id}";
        }
    }
}
