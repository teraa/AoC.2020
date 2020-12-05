using System;
using System.Collections;

const int len = 10;
var seats = new BitArray(1 << len);
string? line;
while ((line = Console.ReadLine()) is not null)
{
    int id = 0;

    for (int i = 0; i < len; i++)
        if (line[i] is 'B' or 'R')
            id |= (1 << (len - i - 1));

    seats[id] = true;
}

for (int i = 1; i < seats.Length - 1; i++)
    if (seats[i - 1] && !seats[i] && seats[i + 1])
        Console.WriteLine(i);