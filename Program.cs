using System;
using System.Collections;
using System.Collections.Generic;

public class Cafe
{
    public string Name { get; set; }
    public string Position { get; set; }
    public Cafe(string name, string position)
    {
        Name = name;
        Position = position;
    }
    public override string ToString()
    {
        return $"{Name} ({Position})";
    }
}

public class Employee : IEnumerable<Cafe>
{
    private readonly List<Cafe> emploees = new List<Cafe>();
    public void Add(Cafe player) => emploees.Add(player);
    public IEnumerator<Cafe> GetEnumerator() => emploees.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}

class Program
{
    static void Main()
    {
        var employee = new Employee
        {
            new("Mukola", "Barista"),
            new("Vova", "Waiter"),
            new("Sveta", "Cook")

        };
        Console.WriteLine("Cafe employees:");
        foreach (var emploees in employee)
            Console.WriteLine(emploees);

    }
}
