using System;
using System.Collections.Generic;

const int MaxDifference = 3;

var list = new List<int>();
string? line;
while ((line = Console.ReadLine()) is not null)
    list.Add(int.Parse(line));

list.Sort();

int[] differences = new int[MaxDifference];
int previous = 0;
for (int i = 0; i < list.Count; i++)
{
    var current = list[i];
    differences[current - previous - 1]++;
    previous = current;
}

Console.WriteLine(differences[0] * (differences[2] + 1));
