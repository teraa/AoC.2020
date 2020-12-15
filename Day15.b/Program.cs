using System;
using System.Linq;

const int N = 2020;
const int M = 30000000;

var starting = Console.ReadLine()!
    .Split(',')
    .Select(int.Parse)
    .ToArray();

var arr = new int[M];
int i = 0;
while (i < starting.Length)
    arr[starting[i]] = ++i;

int n = 0;
do
{
    var idx = arr[n];
    var next = idx == 0 ? 0 : i - idx;

    arr[n] = i++;
    n = next;

    if (i is N or M)
        Console.WriteLine(n);
} while (i < M);
