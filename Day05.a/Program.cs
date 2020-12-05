using System;

const int len = 10;
int max = 0;
string? line;
while ((line = Console.ReadLine()) is not null)
{
    int id = 0;

    for (int i = 0; i < len; i++)
        if (line[i] is 'B' or 'R')
            id |= (1 << (len - i - 1));

    if (id > max)
        max = id;
}

Console.WriteLine(max);
