using System;
using System.Collections.Generic;

var mem = new Dictionary<ulong, ulong>();
ulong ones = 0;
var floats = new List<int>();
string? line;
while ((line = Console.ReadLine()) is not null)
{
    var span = line.AsSpan();
    if (span[3] == '[')
    {
        var idx = span.IndexOf(']');
        var addr = ulong.Parse(span[4..idx]);
        var val = ulong.Parse(span[(idx + 4)..]);

        addr |= ones;

        for (ulong i = 0; i < (1UL << floats.Count); i++)
        {
            (ulong one, ulong zero) fmask = (0, 0);

            for (int j = 0; j < floats.Count; j++)
            {
                var bit = 1UL << floats[j];

                if (((i >> j) & 1) == 1)
                    fmask.one  |= bit;
                else
                    fmask.zero |= bit;
            }

            mem[addr & ~fmask.zero | fmask.one] = val;
        }
    }
    else
    {
        ones = 0;
        floats = new();
        span = span[7..];

        for (int i = 0; i < span.Length; i++)
        {
            var offset = span.Length - 1 - i;

            switch (span[i])
            {
                case 'X': floats.Add(offset);      break;
                case '1': ones |= (1UL << offset); break;
            }
        }
    }
}

ulong sum = 0;
foreach (var (addr, val) in mem)
    sum += val;

Console.WriteLine(sum);
