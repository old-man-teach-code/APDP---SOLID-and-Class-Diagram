public interface ISwitchable
{
    void TurnOn();
    void TurnOff();
}

public class LightBulb : ISwitchable
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

public class Fan : ISwitchable
{
    public void TurnOn()
    {
        Console.WriteLine("Quạt bật");
    }
    
    public void TurnOff()
    {
        Console.WriteLine("Quạt tắt");
    }
}

public class Switch
{
    private readonly ISwitchable _device;
    
    public Switch(ISwitchable device)
    {
        _device = device;
    }
    
    public void Operate(bool isOn)
    {
        if (isOn)
            _device.TurnOn();
        else
            _device.TurnOff();
    }
}