namespace marking_test_task.Helpers.Faker;

public enum Casing
{
    UPPER,
    LOWER,
    MIXED
}

public class String : ModuleBase
{
    public String(FakerBase faker) : base(faker)
    {
        this.faker = faker;
    }

    private const string UpperChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowerChars = "abcdefghijklmnopqrstuvwxyz";

    private const string CyrillicUpperChars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
    private const string CyrillicLowerChars = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";


    public string FromCharacters(string characters, int min, int max)
    {
        if (characters.Length == 0)
        {
            throw new ArgumentException(
                "Unable to generate string: No characters to select from."
            );
        }

        return new string(
            Multiplicator.UseMultiple(
                x => faker.Helper.GetArrayElement(characters.ToCharArray()),
                min,
                max
            )
        );
    }

    public string FromCharacters(string characters, int count)
    {
        if (count <= 0) return "";

        return FromCharacters(characters, 0, count);
    }

    public string Alpha(int min, int max, Casing casing = Casing.MIXED)
    {
        string charArray = casing switch
        {
            Casing.UPPER => UpperChars,
            Casing.LOWER => LowerChars,
            _ => UpperChars + LowerChars,
        };
        return FromCharacters(charArray, min, max);
    }

    public string Alpha(int count, Casing casing = Casing.MIXED)
    {
        return Alpha(count, count, casing);
    }

    public string CyrillicAlpha(int min, int max, Casing casing = Casing.MIXED)
    {
        string charArray = casing switch
        {
            Casing.UPPER => CyrillicUpperChars,
            Casing.LOWER => CyrillicLowerChars,
            _ => CyrillicUpperChars + CyrillicLowerChars
        };
        return FromCharacters(charArray, min, max);
    }

    public string CyrillicAlpha(int count, Casing casing = Casing.MIXED)
    {
        return CyrillicAlpha(count, count, casing);
    }
}
