public class Bird
{
    public virtual void Fly()
    {
        Console.WriteLine("Chim đang bay");
    }
}

public class Sparrow : Bird
{
    public override void Fly()
    {
        Console.WriteLine("Chim sẻ đang bay");
    }
}

public class Penguin : Bird
{
    public override void Fly()
    {
        throw new NotSupportedException("Chim cánh cụt không biết bay"); // vi phạm tính đúng đắn - Liskov
    }
}