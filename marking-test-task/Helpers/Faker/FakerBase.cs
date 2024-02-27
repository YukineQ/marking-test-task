namespace marking_test_task.Helpers.Faker;

public class FakerBase
{
    public readonly Random _randomizer;
    
    public readonly Number Number;
    public readonly String String;
    public readonly Helper Helper;
    public readonly Date Date;

    public FakerBase()
    {
        _randomizer = new Random();

        Number = new(this);
        String = new(this);
        Helper = new(this);
        Date = new(this);
    }
}
