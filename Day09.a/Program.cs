using System;
using System.Collections.Generic;

const int Preamble = 25;

var data = new List<ulong>();
string? line;
while ((line = Console.ReadLine()) is not null)
    data.Add(ulong.Parse(line));

for (int i = Preamble; i < data.Count; i++)
{
    bool found = false;

    for (int j = i - Preamble; j < i - 1 && !found; j++)
        for (int k = j + 1; k < i && !found; k++)
            if (data[j] + data[k] == data[i])
                found = true;

    if (!found)
    {
        Console.WriteLine(data[i]);
        break;
    }
}
