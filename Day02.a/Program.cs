using System;
using System.Linq;

// min-max c: password
//    i   j    

int valid = 0;

string? line;
while ((line = Console.ReadLine()) is not null)
{
    var span = line.AsSpan();
    var i = span.IndexOf('-');
    var j = span[i..].IndexOf(' ') + i;

    var min = int.Parse(span[..i]);
    var max = int.Parse(span[(i + 1)..j]);
    var c = span[j + 1];
    var password = span[(j + 4)..];

    int count = 0;
    for (int k = 0; k < password.Length; k++)
    {
        if (password[k] == c)
        {
            count++;
            if (count > max)
                break;
        }
    }

    if (count >= min && count <= max)
        valid++;
}

Console.WriteLine(valid);
