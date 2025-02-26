public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }

    public void SaveToDB()
    {
        // Lưu thông tin nhân viên vào database
        Console.WriteLine($"Lưu nhân viên {Name} vào DB");
    }

    public double CalculateTax()
    {
        // Tính thuế
        return Salary * 0.2;
    }

    public void GenerateReport()
    {
        // Tạo báo cáo
        Console.WriteLine($"Báo cáo cho nhân viên {Name} với lương {Salary}");
    }

    public void humanResources()
    {
        Console.WriteLine($"Nhân sự nhận thông tin nhân viên {Name}");
    }
}