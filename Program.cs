using System;
namespace InheritanceApp;

public class City
{
    public string Name { get; set; }
    public string Country { get; set; }
    public int Population { get; set; }

    public City()
    {
        this.Name = "Null";
        this.Country = "Null";
        this.Population = 0;

    }

    public City(string name, string country, int population) : this()
    {
        this.Name = name;
        this.Country = country;
        this.Population = population;
    }

    public static City operator +(City city, int populationIncrease)
    {
        return new City(city.Name, city.Country, city.Population + populationIncrease);
    }

    public static City operator -(City city, int populationDecrease)
    {
        return new City(city.Name, city.Country, city.Population - populationDecrease);
    }

    public static bool operator ==(City city1, City city2)
    {
        return city1.Population == city2.Population;
    }

    public static bool operator !=(City city1, City city2)
    {
        return !(city1 == city2);
    }

    public static bool operator <(City city1, City city2)
    {
        return city1.Population < city2.Population;
    }

    public static bool operator >(City city1, City city2)
    {
        return city1.Population > city2.Population;
    }

    public override bool Equals(object obj)
    {
        if (obj is City otherCity)
        {
            return this.Name == otherCity.Name &&
                   this.Country == otherCity.Country &&
                   this.Population == otherCity.Population;
        }
        return false;
    }
}

class Program
{
    static void Main()
    {
        var city1 = new City("Kyiv", "Ukraine", 2800000);
        var city2 = new City("Lviv", "Ukraine", 720000);

        City increasedCity = city1 + 70000;
        Console.WriteLine($"{increasedCity.Name} population: {increasedCity.Population}");

        City decreasedCity = city2 - 10000;
        Console.WriteLine($"{decreasedCity.Name} population: {decreasedCity.Population}");

        Console.WriteLine($"city1 == city2? {city1 == city2}");
        Console.WriteLine($"city1 != city2? {city1 != city2}");

        Console.WriteLine($"city1 < city2? {city1 < city2}");
        Console.WriteLine($"city1 > city2? {city1 > city2}");

        Console.WriteLine($"city1.Equals(city3)? {city1.Equals(city2)}");
    }
}

/*
Kyiv population: 2870000
Lviv population: 710000
city1 == city2? False
city1 != city2? True
city1 < city2? False
city1 > city2? True
city1.Equals(city3)? False

C:\Users\David\source\repos\ConsoleApp1\ConsoleApp1\bin\Debug\net8.0\ConsoleApp1.exe (process 11412) exited with code 0 (0x0).
Press any key to close this window . . .

 
 
*/
