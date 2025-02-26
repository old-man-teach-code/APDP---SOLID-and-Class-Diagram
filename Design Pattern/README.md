# Các design pattern cơ bản và dễ triển khai

## Mục lục
1. [Singleton](#1-singleton)
2. [Factory Method](#2-factory-method)
3. [Adapter](#3-adapter)
4. [Facade](#4-facade)

## Tham khảo các design pattern tại [đây](https://refactoring.guru/design-patterns)

## 1. Singleton
- Singleton là một trong những design pattern cơ bản nhất, nó đảm bảo rằng một class chỉ có một instance và cung cấp một cách để truy cập nó.
- Singleton pattern thường được sử dụng trong trường hợp cần một class duy nhất để thực hiện một số chức năng như: logging, caching, thread pools, database connections, etc.
### Cách triển khai trong C#
```csharp
public class Singleton // Cách dễ nhất để triển khai Singleton
{
    private static Singleton instance;
    private Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Singleton();
            }
            return instance;
        }
    }
}

public class Client
{
    public void Main()
    {
        Singleton singleton1 = Singleton.Instance;
        Singleton singleton2 = Singleton.Instance;

        if (singleton1 == singleton2)
        {
            System.Console.WriteLine("Singleton: Singleton chỉ có một instance.");
        }
        else
        {
            System.Console.WriteLine("Singleton: Singleton có nhiều instance.");
        }
    }
}
```
### Tham khảo thêm về Singleton tai [đây](https://refactoring.guru/design-patterns/singleton)

### Giải thích:
- `Singleton` class có một private constructor để ngăn việc tạo instance từ bên ngoài.
- `Singleton` class có một static property `Instance` để trả về một instance của `Singleton`.
- `Instance` property kiểm tra xem instance đã được tạo chưa, nếu chưa thì tạo mới instance, nếu đã có thì trả về instance đã tạo.
- `Client` sử dụng `Singleton.Instance` để lấy instance của `Singleton`.
- Điểm mạnh là chỉ có một instance của `Singleton` được tạo ra giúp giảm bộ nhớ và tăng hiệu suất.
- Điểm yếu là không thể tạo được nhiều instance của `Singleton` nếu cần, tính linh hoạt thấp.

## 2. Factory Method
- Factory Method là một design pattern cho phép một class tạo ra một object con của một class khác.
- Factory Method pattern cung cấp một cách để giảm sự phụ thuộc giữa các class.
### Cách triển khai trong C#
```csharp
public interface IProduct
{
    string Operation();
}

public class ConcreteProductA : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProductA}";
    }
}

public class ConcreteProductB : IProduct
{
    public string Operation()
    {
        return "{Result of ConcreteProductB}";
    }
}

public abstract class Creator
{
    public abstract IProduct FactoryMethod();
    public string SomeOperation()
    {
        var product = FactoryMethod();
        return $"Creator: The same creator's code has just worked with {product.Operation()}";
    }
}

public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductA();
    }
}

public class ConcreteCreatorB : Creator
{
    public override IProduct FactoryMethod()
    {
        return new ConcreteProductB();
    }
}

public class Client
{
    public void Main()
    {
        System.Console.WriteLine("Chương trình: Khởi động với ConcreteCreatorA.");
        ClientCode(new ConcreteCreatorA());
        System.Console.WriteLine("");

        System.Console.WriteLine("Chương trình: Khởi động với ConcreteCreatorB.");
        ClientCode(new ConcreteCreatorB());
    }

    public void ClientCode(Creator creator)
    {
        System.Console.WriteLine($"Client: Chương trình không biết creator class nào đang sử dụng, nhưng nó vẫn hoạt động.\n{creator.SomeOperation()}");
    }
}
```

### Giải thích: 
- Interface `IProduct` định nghĩa một phương thức `Operation` mà các class khác sẽ implement.
- `ConcreteProductA` và `ConcreteProductB` là các class implement `IProduct`.
- `Creator` là một abstract class với phương thức `FactoryMethod` trả về một object của `IProduct`.
- `ConcreteCreatorA` và `ConcreteCreatorB` là các class con của `Creator` và implement phương thức `FactoryMethod` để trả về `ConcreteProductA` và `ConcreteProductB` tương ứng.
- Điểm mạnh của Factory Method là giảm sự phụ thuộc giữa các class, giúp dễ dàng mở rộng và bảo trì code, giúp tạo ra các object mà không cần biết cụ thể class nào đang tạo ra object.
- Điểm yếu của Factory Method là cần tạo một class mới cho mỗi object cần tạo ra, dẫn đến tăng số lượng class trong project, làm tăng độ phức tạp của project, gây khó khăn trong việc quản lý code.

### Tham khảo thêm về Factory Method tại [đây](https://refactoring.guru/design-patterns/factory-method)

## 3. Adapter
- Adapter là một design pattern cho phép các interface không tương thích làm việc cùng nhau.
- Adapter pattern cho phép một class hoặc object thay đổi interface của một class hoặc object
### Cách triển khai trong C#
```csharp
public interface ITarget
{
    string GetRequest();
}

public class Adaptee
{
    public string GetSpecificRequest()
    {
        return "Specific request.";
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public string GetRequest()
    {
        return $"This is '{_adaptee.GetSpecificRequest()}'";
    }
}

public class Client
{
    public void Main()
    {
        Adaptee adaptee = new Adaptee();
        ITarget target = new Adapter(adaptee);

        System.Console.WriteLine("Client: Chương trình hoạt động với Adaptee, không thể hoạt động với ITarget.");
        System.Console.WriteLine($"Adaptee: {adaptee.GetSpecificRequest()}"); // Adaptee không thể hoạt động với ITarget
        System.Console.WriteLine("Client: Chương trình hoạt động với ITarget."); // Adapter giúp Adaptee hoạt động với ITarget
        System.Console.WriteLine($"Adapter: {target.GetRequest()}"); // Adapter giúp Adaptee hoạt động với ITarget
    }
}
```

### Giải thích:
- `ITarget` là interface mà client mong muốn sử dụng.
- `Adaptee` là class không tương thích với `ITarget`.
- `Adapter` là class giúp `Adaptee` hoạt động với `ITarget`.
- `Client` là class sử dụng `ITarget` và `Adaptee` thông qua `Adapter`.
- `Adapter` chứa một object của `Adaptee` và implement `ITarget` để chuyển đổi `Adaptee` thành `ITarget`.
- `Client` sử dụng `Adapter` để hoạt động với `Adaptee` thông qua `ITarget`.
- `Adapter` giúp `Adaptee` hoạt động với `ITarget` mà không cần thay đổi code của `Adaptee`.
- Điểm mạnh của Adapter là giảm sự phụ thuộc giữa các class, giúp dễ dàng mở rộng và bảo trì code, giúp các class không tương thích làm việc cùng nhau dễ dàng hơn. Có thể sử dụng Adapter để thay đổi logic của một class mà không cần thay đổi code của class đó.
- Điểm yếu của Adapter là tăng số lượng class trong project, làm tăng độ phức tạp của project. Nếu sử dụng nhiều Adapter, dễ dẫn đến việc khó quản lý code.

### Tham khảo thêm về Adapter tại [đây](https://refactoring.guru/design-patterns/adapter)

## 4. Facade
- Facade là một design pattern cung cấp một interface đơn giản cho một hệ thống phức tạp.
- Facade pattern giúp giảm sự phức tạp của hệ thống bằng cách cung cấp một interface đơn giản cho client.
- Facade tổng hợp các class phức tạp thành một class đơn giản.
### Cách triển khai trong C#
```csharp
public class Subsystem1
{
    public void Operation1()
    {
        System.Console.WriteLine("Subsystem1: Ready!");
    }
}

public class Subsystem2
{
    public void Operation2()
    {
        System.Console.WriteLine("Subsystem2: Get ready!");
    }
}

public class Subsystem3
{
    public void Operation3()
    {
        System.Console.WriteLine("Subsystem3: Go!");
    }
}

public class Facade
{
    private readonly Subsystem1 _subsystem1;
    private readonly Subsystem2 _subsystem2;
    private readonly Subsystem3 _subsystem3;

    public Facade(Subsystem1 subsystem1, Subsystem2 subsystem2, Subsystem3 subsystem3)
    {
        _subsystem1 = subsystem1;
        _subsystem2 = subsystem2;
        _subsystem3 = subsystem3;
    }

    public void Operation1and2and3()
    {
        System.Console.WriteLine("Facade: Ready, Get ready, Go!");
        _subsystem1.Operation1();
        _subsystem2.Operation2();
        _subsystem3.Operation3();
    }

    public void Operation2and3()
    {
        System.Console.WriteLine("Facade: Get ready, Go!");
        _subsystem2.Operation2();
        _subsystem3.Operation3();
    }

    public void Operation3()
    {
        System.Console.WriteLine("Facade: Go!");
        _subsystem3.Operation3();
    }

    public void Operation1()
    {
        System.Console.WriteLine("Facade: Ready!");
        _subsystem1.Operation1();
    }

    public void Operation2()
    {
        System.Console.WriteLine("Facade: Get ready!");
        _subsystem2.Operation2();
    }
}

public class Client
{
    public void Main()
    {
        Subsystem1 subsystem1 = new Subsystem1();
        Subsystem2 subsystem2 = new Subsystem2();
        Subsystem3 subsystem3 = new Subsystem3();

        Facade facade = new Facade(subsystem1, subsystem2, subsystem3);

        System.Console.WriteLine("Client: Chương trình hoạt động với Facade.");
        facade.Operation1and2and3();
        System.Console.WriteLine("");

        System.Console.WriteLine("Client: Chương trình hoạt động với Subsystem1.");
        subsystem1.Operation1();
        System.Console.WriteLine("");

        System.Console.WriteLine("Client: Chương trình hoạt động với Subsystem2.");
        subsystem2.Operation2();
        System.Console.WriteLine("");

        System.Console.WriteLine("Client: Chương trình hoạt động với Subsystem3.");
        subsystem3.Operation3();
    }
}
```

### Tham khảo thêm về Facade tại [đây](https://refactoring.guru/design-patterns/facade)

### Giải thích:
- `Subsystem1`, `Subsystem2`, `Subsystem3` là các class phức tạp.
- `Facade` là class đơn giản cung cấp interface cho client.
- `Facade` tổng hợp các class phức tạp thành một class đơn giản.
- `Client` sử dụng `Facade` để hoạt động với các class phức tạp.
- Nếu không sử dụng `Facade`, client phải gọi các phương thức của các class phức tạp một cách riêng lẻ.
- Nếu cần thay đổi logic của các class phức tạp, chỉ cần thay đổi trong `Facade` mà không cần thay đổi trong client.
- Điểm mạnh của Facade là giảm sự phức tạp của hệ thống, giúp dễ dàng mở rộng và bảo trì code, giúp client không cần biết về các class phức tạp, chỉ cần sử dụng `Facade` có thể tương tác với nhiều class phức tạp.
- Điểm yếu của Facade là tăng số lượng class trong project, làm tăng độ phức tạp của project, 1 class `Facade` có thể chứa nhiều phương thức, dẫn đến việc class `Facade` gia tăng kích thước. Khi `Facade` được khởi tạo, tất cả các class phức tạp cũng được khởi tạo, dẫn đến tăng bộ nhớ.

