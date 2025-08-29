using System;
using System.Linq;

class Progtam
{
    static void Main(string[] args)
    {
        int[] numbers = { 56, 89, 1, 67, 0, 3, 23 };
        var ascending = numbers.OrderBy(n => Summa(n));
        var descending = numbers.OrderByDescending(n => Summa(n));

        Console.WriteLine("Array: " + string.Join(", ", numbers));
        Console.WriteLine("Ascending: " + string.Join(", ", ascending));
        Console.WriteLine("Descending: " + string.Join(", ", descending));
    }
    static int Summa(int n)
    {
        return n.ToString().Sum(c => c - '0');
    }
}