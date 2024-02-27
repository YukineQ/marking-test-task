namespace marking_test_task.Helpers.Faker;

public class Date : ModuleBase
{
    public Date(FakerBase faker) : base(faker)
    {
        this.faker = faker;
    }

    public DateTime Between(DateTime? from = null, DateTime? to = null)
    {
        var fromMs = GetTimestamp(from ?? DateTime.Now);
        var toMs = GetTimestamp(to ?? DateTime.Now);
        var dateOffset = faker.Number.Long(fromMs, toMs);

        return ConvertTimestampToDate(dateOffset);
    }

    public DateTime Between(string from, string to)
    {
        var toDate = DateTime.Parse(to);
        var fromDate = DateTime.Parse(from);

        return Between(fromDate, toDate);
    }

    public DateTime Past(int years = 1, DateTime? refDate = null)
    {
        if (years <= 0)
        {
            throw new ArgumentException("Years must be greater than 0.");
        }

        var pastDate = DateTime.UtcNow.AddYears(-years);

        return Between(pastDate);
    }

    private long GetTimestamp(DateTime date)
    {
        return ((DateTimeOffset)date).ToUnixTimeSeconds();
    }

    private DateTime ConvertTimestampToDate(long timestamp)
    {
        DateTime dateTime = DateTime.UnixEpoch;
        return dateTime.AddSeconds(timestamp).ToLocalTime();
    }
}
