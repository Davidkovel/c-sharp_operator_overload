using System;
namespace InheritanceApp;

class Employee
{
    private string name { get; set; }
    private double salary { get; set; }

    public Employee() 
    {
        this.name = "Null";
        this.salary = 0;
    }
    public Employee(string name, double salary) : this()
    {
        this.name = name;
        this.salary = salary;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Salary
    {
        get { return salary; }
        set { salary = value; }
    }

    public static Employee operator +(Employee emp, double amount)
    {
        emp.salary += amount;
        return emp;
    }

    public static Employee operator -(Employee emp, double amount)
    {
        try
        {
            if (emp.salary - amount >= 0)
            {
                emp.salary -= amount;
            }
            else
            {

                throw new Exception("Salary can not be less than 0!");
            }
            return emp;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return emp;
        }
    }

    public static bool operator ==(Employee emp1, Employee emp2)
    {
        return emp1.salary == emp2.salary;
    }

    public static bool operator !=(Employee emp1, Employee emp2)
    {
        return emp1.salary != emp2.salary;
    }

    public static bool operator <(Employee emp1, Employee emp2)
    {
        return emp1.salary < emp2.salary;
    }

    public static bool operator >(Employee emp1, Employee emp2)
    {
        return emp1.salary > emp2.salary;
    }

    public override bool Equals(object obj)
    {
        if (obj is Employee other)
        {
            return this == other;
        }
        return false;
    }

    public void Display()
    {
        Console.WriteLine($"Name: {name}, Salary: {salary}");
    }
}

class Program
{
    static void Main()
    {
        Employee emp1 = new Employee("Vova bob", 5000);
        Employee emp2 = new Employee("Bob", 7000);

        emp1.Display();
        emp2.Display();

        emp1 += 2500;
        emp1.Display();

        emp2 -= 3000;
        emp2.Display();

        Console.WriteLine($"Are salaries the same? {(emp1 == emp2 ? "Yes" : "No")}");
        Console.WriteLine($"Has {emp1.Name} more money? {(emp1 > emp2 ? "Yes" : "No")}");

        Console.WriteLine($"Are they the same?: {(emp1.Equals(emp2) ? "Yes" : "No")}");
    }
}

/*
Name: Vova bob, Salary: 5000
Name: Bob, Salary: 7000
Name: Vova bob, Salary: 7500
Name: Bob, Salary: 4000
Are salaries the same? No
Has Vova bob more money? Yes
Are they the same?: No

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 12484) exited with code 0 (0x0).
Press any key to close this window . . . 
*/