using System;
using System.Collections.Generic;


var list = new List<int>();
string? line;
while ((line = Console.ReadLine()) is not null)
    list.Add(int.Parse(line));


list.Sort();
list.Insert(0, 0);

ulong product = 1;
for (int i = 0; i < list.Count - 1;)
{
    int current = list[i];
    int count = 0;
    for (int j = i + 1; j < list.Count; j++)
    {
        var next = list[j];

        if (next - current != 1)
            break;

        current = next;
        count++;
    }

    product *= (count + 1) switch
    {
        < 3 => 1,
        3 => 2,
        4 => 4,
        5 => 7,
        _ => throw new ArgumentOutOfRangeException()
    };

    if (count == 0)
        i++;
    else
        i += count + 1;
}

Console.WriteLine(product);
