using System;
using System.Collections.Generic;

var list = new List<int>() { 0 };
string? line;
while ((line = Console.ReadLine()) is not null)
    list.Add(int.Parse(line));

list.Sort();

ulong product = 1;
int i = 0;
while (i < list.Count)
{
    int start = i++;
    while (i < list.Count && (list[i] - list[i - 1]) <= 1) i++;

    product *= (i - start) switch
    {
        < 3 => 1,
        3 => 2,
        4 => 4,
        5 => 7,
        _ => throw new ArgumentOutOfRangeException()
    };
}

Console.WriteLine(product);
