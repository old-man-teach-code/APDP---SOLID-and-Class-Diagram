public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

public interface ISleepable
{
    void Sleep();
}

public class Human : IWorkable, IEatable, ISleepable
{
    public void Work()
    {
        Console.WriteLine("Con người đang làm việc");
    }
    
    public void Eat()
    {
        Console.WriteLine("Con người đang ăn");
    }
    
    public void Sleep()
    {
        Console.WriteLine("Con người đang ngủ");
    }
}

public class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot đang làm việc");
    }
}