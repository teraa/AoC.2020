using System;
using System.Linq;

var min = int.Parse(Console.ReadLine()!);
var ids = Console.ReadLine()!
    .Split(',')
    .Where(x => x != "x")
    .Select(int.Parse)
    .ToList();

for (int i = min; true; i++)
{
    for (int j = 0; j < ids.Count; j++)
    {
        var id = ids[j];
        if (i % id == 0)
        {
            Console.WriteLine((i - min) * id);
            return;
        }
    }
}
