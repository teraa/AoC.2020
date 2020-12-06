using System;
using System.Collections.Generic;
using System.Linq;

string[] required = { "byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid" };

int valid = 0;
var fields = new List<string>();
string? line;
do
{
    line = Console.ReadLine();

    if (line is null || line.Length == 0)
    {
        if (!required.Except(fields).Any())
            valid++;

        if (line is not null)
            fields = new();
    }
    else
    {
        var pairs = line.Split(' ');
        foreach (var pair in pairs)
        {
            var key = pair.Split(':')[0];
            fields.Add(key);
        }
    }
} while (line is not null);

Console.WriteLine(valid);
