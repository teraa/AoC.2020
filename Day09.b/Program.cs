using System;
using System.Collections.Generic;

const int Preamble = 25;

var data = new List<ulong>();
string? line;
while ((line = Console.ReadLine()) is not null)
    data.Add(ulong.Parse(line));

ulong sum = 0;
for (int i = Preamble; i < data.Count; i++)
{
    bool found = false;

    for (int j = i - Preamble; j < i - 1 && !found; j++)
        for (int k = j + 1; k < i && !found; k++)
            if (data[j] + data[k] == data[i])
                found = true;

    if (!found)
    {
        sum = data[i];
        Console.WriteLine(sum);
        break;
    }
}

for (int i = 0; i < data.Count; i++)
{
    ulong currentSum = 0;
    ulong min = ulong.MaxValue, max = 0;
    for (int j = i; j < data.Count; j++)
    {
        var n = data[j];
        if (n < min) min = n;
        if (n > max) max = n;

        currentSum += n;
        if (currentSum >= sum)
            break;
    }

    if (currentSum == sum)
    {
        Console.WriteLine(min + max);
        break;
    }
}
