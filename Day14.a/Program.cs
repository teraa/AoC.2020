using System;
using System.Collections.Generic;

var mem = new Dictionary<ulong, ulong>();
(ulong zero, ulong one) mask = (0, 0);
string? line;
while ((line = Console.ReadLine()) is not null)
{
    var span = line.AsSpan();
    if (span[3] == '[')
    {
        var idx = span.IndexOf(']');
        var addr = ulong.Parse(span[4..idx]);
        var val = ulong.Parse(span[(idx + 4)..]);

        mem[addr] = val & ~mask.zero | mask.one;
    }
    else
    {
        mask = (0, 0);
        span = span[7..];

        for (int i = 0; i < span.Length; i++)
        {
            var bit = (1UL << (span.Length - 1 - i));

            switch (span[i])
            {
                case '0': mask.zero |= bit; break;
                case '1': mask.one  |= bit; break;
            }
        }
    }
}

ulong sum = 0;
foreach (var (addr, val) in mem)
    sum += val;

Console.WriteLine(sum);
