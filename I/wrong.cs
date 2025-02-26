public interface IWorker
{
    void Work();
    void Eat();
    void Sleep();
}

public class Human : IWorker
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

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot đang làm việc");
    }
    
    public void Eat()
    {
        throw new NotSupportedException("Robot không ăn"); // vi phạm tính đúng đắn - Interface Segregation
    }
    
    public void Sleep()
    {
        throw new NotSupportedException("Robot không ngủ"); // vi phạm tính đúng đắn - Interface Segregation
    }
}