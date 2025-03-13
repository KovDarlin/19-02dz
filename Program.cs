using System;
using System.Collections;
using System.Collections.Generic;

public class Football
{
    public string Name { get; set; }
    public string Position { get; set; }
    public Football(string name, string position)
    {
        Name = name;
        Position = position;
    }
    public override string ToString()
    {
        return $"{Name} ({Position})";
    }
}

public class Team : IEnumerable<Football>
{
    private readonly List<Football> players = new List<Football>();
    public void Add(Football player) => players.Add(player);
    public IEnumerator<Football> GetEnumerator() => players.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

}

class Program
{
    static void Main()
    {
        var team = new Team
        {
            new("Lionel Messi", "Striker"),
            new("Cristiano Ronaldo", "Striker"),
            new("Manuel Neuer", "Goalkeeper")

        };
        Console.WriteLine("Football players:");
        foreach (var player in team)
            Console.WriteLine(player);

    }
}
