using System;
using System.Collections.Generic;

int sum = 0;
HashSet<char>? answers = null;
string? line;
do
{
    line = Console.ReadLine();

    if (string.IsNullOrEmpty(line))
    {
        if (answers is not null)
            sum += answers.Count;

        answers = null;
    }
    else
    {
        if (answers is null)
            answers = new(line);
        else
            answers.UnionWith(line);
    }
} while (line is not null);

Console.WriteLine(sum);
