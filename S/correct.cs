public class Employee
{
    public string Name { get; set; }
    public double Salary { get; set; }
}

public class EmployeeRepository
{
    public void Save(Employee employee)
    {
        // Lưu thông tin nhân viên vào database
        Console.WriteLine($"Lưu nhân viên {employee.Name} vào DB");
    }
}

public class TaxCalculator
{
    public double CalculateTax(Employee employee)
    {
        // Tính thuế dựa trên lương
        return employee.Salary * 0.2;
    }
}

public class ReportGenerator
{
    public void GenerateReport(Employee employee)
    {
        // Tạo báo cáo
        Console.WriteLine($"Báo cáo cho nhân viên {employee.Name} với lương {employee.Salary}");
    }
}

public class HumanResources
{
    public void ReceiveInformation(Employee employee)
    {
        Console.WriteLine($"Nhân sự nhận thông tin nhân viên {employee.Name}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee employee = new Employee
        {
            Name = "John",
            Salary = 1000
        };

        EmployeeRepository repository = new EmployeeRepository();
        repository.Save(employee); // Lưu thông tin nhân viên vào database - tác nhân là John

        TaxCalculator taxCalculator = new TaxCalculator();
        double tax = taxCalculator.CalculateTax(employee); // Tính thuế cho nhân viên - tác nhân là John
        Console.WriteLine($"Thuế của nhân viên {employee.Name} là {tax}");

        ReportGenerator reportGenerator = new ReportGenerator();
        reportGenerator.GenerateReport(employee); // Tạo báo cáo cho nhân viên - tác nhân là John

        HumanResources humanResources = new HumanResources();
        humanResources.ReceiveInformation(employee); // Nhân sự nhận thông tin nhân viên - tác nhân là John
    }
}