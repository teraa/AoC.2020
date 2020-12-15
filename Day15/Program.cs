using System;
using System.Collections.Generic;
using System.Linq;

const int N = 2020;
const int M = 30000000;

var dict = new Dictionary<int, List<int>>();
var starting = Console.ReadLine()!
    .Split(',')
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < starting.Length; i++)
    dict[starting[i]] = new() { i + 1 };

int last = starting[^1];
for (int i = dict.Count + 1; i <= M; i++)
{
    var indexes = dict[last];

    if (indexes.Count == 1)
        last = 0;
    else
        last = indexes[^1] - indexes[^2];

    if (dict.TryGetValue(last, out indexes))
        indexes.Add(i);
    else
        dict[last] = new() { i };

    if (i is N or M)
        Console.WriteLine(last);
}
