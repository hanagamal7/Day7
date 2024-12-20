using System;

namespace Day7
{

    // Problem 1: Car Class with Multiple Constructors
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Price { get; set; }

        // Default Constructor
        public Car()
        {
            Id = 0;
            Brand = "Unknown";
            Price = 0.0;
        }

        // Constructor with one parameter (Id)
        public Car(int id)
        {
            Id = id;
            Brand = "Unknown";
            Price = 0.0;
        }

        // Constructor with two parameters (Id, Brand)
        public Car(int id, string brand)
        {
            Id = id;
            Brand = brand;
            Price = 0.0;
        }

        // Constructor with all three parameters
        public Car(int id, string brand, double price)
        {
            Id = id;
            Brand = brand;
            Price = price;
        }
    }

    //question1.1: Defining a custom constructor suppresses the default constructor because C# assumes that the developer explicitly defines all constructors needed. If no constructors are provided, a default one is generated automatically.

    // Problem 2: Calculator Class with Overloaded Methods
    public class Calculator
    {
        // Add two integers
        public int Sum(int a, int b) => a + b;

        // Add three integers
        public int Sum(int a, int b, int c) => a + b + c;

        // Add two doubles
        public double Sum(double a, double b) => a + b;
    }

    //question1.2: Method overloading improves code readability and reusability by allowing methods with the same name but different parameters, making it easier to understand and use without requiring different method names.

    // Problem 3: Constructor Chaining
    public class Parent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Parent(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public class Child : Parent
    {
        public int Z { get; set; }

        public Child(int x, int y, int z) : base(x, y)
        {
            Z = z;
        }
    }

    //question1.3: Constructor chaining ensures the base class is properly initialized before executing derived class-specific logic.

    // Problem 4: Overriding Methods
    public class OverridingParent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public virtual int Product() => X * Y;
    }

    public class OverridingChild : OverridingParent
    {
        // Using "new" keyword
        public new int Product() => X + Y;

     
    }

    //question1.4: The "new" keyword hides the base method, while "override" replaces it. The choice determines whether base or derived behavior is invoked via polymorphism.

    // Problem 5: Overriding ToString
    public class ToStringParent
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString() => $"({X}, {Y})";
    }

    public class ToStringChild : ToStringParent
    {
        public int Z { get; set; }

        public override string ToString() => $"({X}, {Y}, {Z})";
    }

    //question1.5: Overriding ToString() provides a custom string representation of objects, improving debugging and readability.

    // Problem 6: Interface Implementation
    public interface IShape
    {
        double Area { get; }
        void Draw();
    }

    public class Rectangle : IShape
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Area => Length * Width;

        public void Draw() => Console.WriteLine("Drawing Rectangle");
    }

    //question1.6: Interfaces can't be instantiated directly because they are contracts that define methods/properties but lack implementations.

    internal class Program
    {
        static void Main(string[] args)
        {
            // Testing Car Class
            var car1 = new Car();
            var car2 = new Car(1);
            var car3 = new Car(2, "Toyota");
            var car4 = new Car(3, "BMW", 50000.0);

            // Testing Calculator
            var calculator = new Calculator();
            Console.WriteLine(calculator.Sum(2, 3));
            Console.WriteLine(calculator.Sum(1, 2, 3));
            Console.WriteLine(calculator.Sum(2.5, 3.5));

            // Testing Constructor Chaining
            var child = new Child(1, 2, 3);

            // Testing Method Overriding
            OverridingParent obj1 = new OverridingParent { X = 4, Y = 5 };
            OverridingChild obj2 = new OverridingChild { X = 4, Y = 5 };
            Console.WriteLine(obj1.Product()); // Base behavior
            Console.WriteLine(obj2.Product()); // Derived behavior

            // Testing ToString
            var parent = new ToStringParent { X = 4, Y = 5 };
            var child2 = new ToStringChild { X = 4, Y = 5, Z = 6 };
            Console.WriteLine(parent);
            Console.WriteLine(child2);

            // Testing Interface
            IShape rect = new Rectangle { Length = 5, Width = 4 };
            Console.WriteLine($"Area: {rect.Area}");
            rect.Draw();
        }
    }
}
