public interface IBird
{
    void Move();
}

public interface IFlyingBird : IBird
{
    void Fly();
}

public class Sparrow : IFlyingBird
{
    public void Move()
    {
        Console.WriteLine("Chim sẻ đang di chuyển");
    }
    
    public void Fly()
    {
        Console.WriteLine("Chim sẻ đang bay");
    }
}

public class Penguin : IBird
{
    public void Move()
    {
        Console.WriteLine("Chim cánh cụt đang bơi hoặc đi bộ");
    }
}