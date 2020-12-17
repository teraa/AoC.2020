using System;
using System.Collections.Generic;

const int Cycles = 6;

var points = new HashSet<Point>();
string? line;
int x, y;
x = y = 0;
while ((line = Console.ReadLine()) is not null)
{
    for (y = 0; y < line.Length; y++)
        if (line[y] == '#')
            points.Add(new Point(x, y, 0));

    x++;
}

var min = new Point(0, 0, 0);
var max = new Point(x - 1, y - 1, 0);

for (int cycle = 0; cycle < Cycles; cycle++)
{
    var newPoints = new HashSet<Point>(points);

    min = new Point(min.X - 1, min.Y - 1, min.Z - 1);
    max = new Point(max.X + 1, max.Y + 1, max.Z + 1);

    for (int z = min.Z; z <= max.Z; z++)
    {
        for (y = min.Y; y <= max.Y; y++)
        {
            for (x = min.X; x <= max.X; x++)
            {
                var point = new Point(x, y, z);
                var count = CountActiveNeighbors(point);
                if (points.Contains(point))
                {
                    if (count is not (2 or 3))
                        newPoints.Remove(point);
                }
                else
                {
                    if (count is 3)
                        newPoints.Add(point);
                }
            }
        }
    }

    points = newPoints;
}

Console.WriteLine(points.Count);

int CountActiveNeighbors(Point point)
{
    int count = 0;

    for (int z = -1; z <= 1; z++)
    {
        for (int y = -1; y <= 1; y++)
        {
            for (int x = -1; x <= 1; x++)
            {
                if (x == 0 && y == 0 && z == 0) continue;

                var neighbor = new Point
                (
                    point.X + x,
                    point.Y + y,
                    point.Z + z
                );

                if (points.Contains(neighbor))
                    count++;

                // we don't care if there are more
                if (count > 3) return count;
            }
        }
    }

    return count;
}

record Point(int X, int Y, int Z);
