using System;
using System.Collections.Generic;
using System.Linq;

const int N = 2020;
const int M = 30000000;

var starting = Console.ReadLine()!
    .Split(',')
    .Select(int.Parse)
    .ToArray();

var dict = new Dictionary<int, int>();
int i = 0;
while (i < starting.Length)
    dict[starting[i]] = ++i;

int n = 0;
do
{
    var next = dict.TryGetValue(n, out var idx)
        ? i - idx
        : 0;

    dict[n] = i++;
    n = next;

    if (i is N or M)
        Console.WriteLine(n);
} while (i < M);
