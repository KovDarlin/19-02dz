using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Product<T>
{
    public string Name { get; }
    public decimal Price { get; }
    public DateTime DateAdded { get; }

    public Product(string name, decimal price, DateTime dateAdded)
    {
        Name = name;
        Price = price;
        DateAdded = dateAdded;
    }

    public override string ToString() => $"{Name} - {Price}$. (Added: {DateAdded:dd.MM.yyyy})";
}

public class Category<T> : IEnumerable<Product<T>>
{
    private readonly List<Product<T>> products = new();

    public void Add(Product<T> product) => products.Add(product);

    public IEnumerable<Product<T>> FilterByPrice(decimal minPrice, decimal maxPrice) =>
        products.Where(p => p.Price >= minPrice && p.Price <= maxPrice);

    public IEnumerable<Product<T>> FilterByDate(DateTime sinceDate) =>
        products.Where(p => p.DateAdded >= sinceDate);

    public IEnumerator<Product<T>> GetEnumerator() => products.GetEnumerator();
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

class Program
{
    static void Main()
    {
        var electronics = new Category<string>
        {
            new("Samsung Galaxy A21", 450, DateTime.Now.AddDays(-100)),
            new("Redmi", 1200, DateTime.Now.AddDays(-90)),
            new("Samsung Tab", 300, DateTime.Now.AddDays(-2))
        };

        Console.WriteLine("All product:");
        foreach (var item in electronics)
            Console.WriteLine(item);

        Console.WriteLine("\nFilter price (100 - 500):");
        foreach (var item in electronics.FilterByPrice(100, 500))
            Console.WriteLine(item);

        Console.WriteLine("\nFilter date (this month):");
        foreach (var item in electronics.FilterByDate(DateTime.Now.AddMonths(-1)))
            Console.WriteLine(item);
    }
}
