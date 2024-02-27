namespace marking_test_task.Helpers.Faker;

public class Randomizer
{
    public Random randomizer = new Random();

    public void Seed(int value)
    {
        randomizer = new Random(value);
    }
}
