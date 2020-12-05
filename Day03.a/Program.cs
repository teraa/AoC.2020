using System;
using System.Collections.Generic;

var points = new HashSet<(int, int)>();
int len = 0;
int rows = 0;
string? line;
while ((line = Console.ReadLine()) is not null)
{
    len = line.Length;

    for (int j = 0; j < len; j++)
        if (line[j] == '#')
            points.Add((rows, j));

    rows++;
}

int hits = 0;
for (int x = 0, y = 0; x < rows; x++, y = (y + 3) % len)
    if (points.Contains((x, y)))
        hits++;

Console.WriteLine(hits);