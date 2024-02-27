namespace marking_test_task.Helpers.Faker;

public class Number : ModuleBase
{
    public Number(FakerBase faker) : base(faker)
    {
        this.faker = faker;
    }

    public int Integer(int min = 0, int max = int.MaxValue)
    {
        if (max == min) return min;

        return faker._randomizer.Next(min, max);
    }

    public double Double(double min = 0.0d, double max = 1.0d)
    {
        if (min == max) return min;

        return faker._randomizer.NextDouble() * (max - min) + min;
    }

    public float Float(float min = 0.0f, float max = 1.0f)
    {
        return Convert.ToSingle(Double() * (max - min) + min);
    }

    public long Long(long min = long.MinValue, long max = long.MaxValue)
    {
        var range = (decimal)max - min;
        return Convert.ToInt64((decimal)Double() * range + min);
    }
}
