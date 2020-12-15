using System;
using System.Collections.Generic;
using System.Linq;

const int N = 2020;
const int M = 30000000;

var dict = new Dictionary<int, (int, int)>();
var starting = Console.ReadLine()!
    .Split(',')
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < starting.Length; i++)
    dict[starting[i]] = (i + 1, -1);

int last = starting[^1];
for (int i = dict.Count + 1; i <= M; i++)
{
    var indexes = dict[last];

    last = indexes.Item2 == -1
        ? 0
        : indexes.Item1 - indexes.Item2;

    dict[last] = dict.TryGetValue(last, out indexes)
        ? (i, indexes.Item1)
        : (i, -1);

    if (i is N or M)
        Console.WriteLine(last);
}
