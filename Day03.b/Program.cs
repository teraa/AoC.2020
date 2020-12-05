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

var offsets = new List<(int x, int y)>
{
    (1, 1),
    (1, 3),
    (1, 5),
    (1, 7),
    (2, 1),
};

long prod = 1;
foreach (var offset in offsets)
{
    int hits = 0;
    for (int x = 0, y = 0; x < rows; x += offset.x, y = (y + offset.y) % len)
        if (points.Contains((x, y)))
            hits++;

    prod *= hits;
}

Console.WriteLine(prod);