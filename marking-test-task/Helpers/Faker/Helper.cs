namespace marking_test_task.Helpers.Faker;

public class Helper : ModuleBase
{
    public Helper(FakerBase faker) : base(faker)
    {
        this.faker = faker;
    }

    public TSource GetArrayElement<TSource>(TSource[] array)
    {
        var arrLen = array.Length;
        var index = arrLen > 1
            ? faker.Number.Integer(max: arrLen - 1)
            : 0;

        return array[index];
    }
}
