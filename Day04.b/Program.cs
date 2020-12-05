using System;
using System.Collections.Generic;
using System.Linq;

// byr (Birth Year) - four digits; at least 1920 and at most 2002.
// iyr (Issue Year) - four digits; at least 2010 and at most 2020.
// eyr (Expiration Year) - four digits; at least 2020 and at most 2030.
// hgt (Height) - a number followed by either cm or in:
//     If cm, the number must be at least 150 and at most 193.
//     If in, the number must be at least 59 and at most 76.
// hcl (Hair Color) - a # followed by exactly six characters 0-9 or a-f.
// ecl (Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
// pid (Passport ID) - a nine-digit number, including leading zeroes.
// cid (Country ID) - ignored, missing or not.

namespace Day04
{
    class Program
    {
        static readonly string[] ValidEcl = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        static readonly Dictionary<string, Func<string, bool>> Rules = new()
        {
            ["byr"] = x => int.TryParse(x, out var d) && d is >= 1920 and <= 2002,
            ["iyr"] = x => int.TryParse(x, out var d) && d is >= 2010 and <= 2020,
            ["eyr"] = x => int.TryParse(x, out var d) && d is >= 2020 and <= 2030,
            ["hgt"] = x =>
            {
                var span = x.AsSpan();

                if (!(span.Length > 2 && int.TryParse(span[..^2], out var height)))
                    return false;

                return (span[^2..].ToString(), height)
                    is ("cm", >= 150 and <= 193)
                    or ("in", >= 59 and <= 76);
            },
            ["hcl"] = x
                => x.Length == 7
                && x[0] == '#'
                && int.TryParse(x[1..], System.Globalization.NumberStyles.HexNumber, default, out _),
            ["ecl"] = x => ValidEcl.Contains(x),
            ["pid"] = x
                => x.Length == 9
                && int.TryParse(x, out _),
        };

        static void Main()
        {
            int valid = 0;
            var fields = new Dictionary<string, string>();
            string? line;
            do
            {
                line = Console.ReadLine();

                if (line is null || line.Length == 0)
                {
                    if (TestFields(fields))
                        valid++;

                    if (line is not null)
                        fields = new();
                }
                else
                {
                    var pairs = line.Split(' ');
                    foreach (var pair in pairs)
                    {
                        var parts = pair.Split(':', 2);
                        var key = parts[0];
                        var value = parts[1];
                        fields[key] = value;
                    }
                }
            } while (line is not null);

            Console.WriteLine(valid);
        }

        public static bool TestField(string key, string value)
        {
            return key == "cid" || Rules[key](value);
        }

        public static bool TestFields(Dictionary<string, string> fields)
        {
            if (Rules.Keys.Except(fields.Keys).Any())
                return false;

            foreach (var field in fields)
                if (!TestField(field.Key, field.Value))
                    return false;

            return true;
        }
    }
}
