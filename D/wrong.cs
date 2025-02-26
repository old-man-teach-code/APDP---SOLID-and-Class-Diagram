public class LightBulb
{
    public void TurnOn()
    {
        Console.WriteLine("Đèn bật");
    }
    
    public void TurnOff()
    {
        Console.WriteLine("Đèn tắt");
    }
}

public class Switch
{
    private readonly LightBulb _bulb;
    
    public Switch()
    {
        _bulb = new LightBulb();
    }
    
    public void Operate(bool isOn)
    {
        if (isOn)
            _bulb.TurnOn();
        else
            _bulb.TurnOff();
    }
}