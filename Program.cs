using System;
using System.Collections;
using System.Collections.Generic;

public class Oceanarium
{
    public string Name { get; set; }
    public string Kind { get; set; }
    public Oceanarium(string name, string kind)
    {
        Name = name;
        Kind = kind;
    }
    public override string ToString()
    {
        return $"{Name} ({Kind})";
    }
}

public class Ocean<T>:IEnumerable<T> where T : Oceanarium
{
    private readonly List<T> fish = new List<T>();
    public void Add(T creature) => fish.Add(creature);
    public IEnumerator<T> GetEnumerator() => fish.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}

class Program
{
    static void Main()
    {
        var oceanarium = new Ocean<Oceanarium>
        {
            new("cod","kind1"),
            new("carp","kind2"),
            new("dorado","kind3"),
            new("shark","kind4"),

        };
        Console.WriteLine("Fish in oceanarium:");
        foreach (var creature in oceanarium)
            Console.WriteLine(creature);
            
    }
}

