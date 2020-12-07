using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

const string Wanted = "shiny gold";

var regex = new Regex(@"(?<parent>.*?) bags contain (?:(?<child>\d+ .*?) bags?(?:\.|, ))*", RegexOptions.Compiled);
var dict = new Dictionary<string, Dictionary<string, int>>();
string? line;
while ((line = Console.ReadLine()) is not null)
{
    var match = regex.Match(line);
    var parentName = match.Groups["parent"].Value;
    var d = new Dictionary<string, int>();
    dict[parentName] = d;

    var children = match.Groups["child"].Captures;
    foreach (Capture cc in children)
    {
        var parts = cc.Value.Split(' ', 2);
        var count = int.Parse(parts[0]);
        var name = parts[1];
        d[name] = count;
    }
}

bool Predicate(string name)
{
    var subDict = dict[name];
    return subDict.Keys.Any(x => x == Wanted || Predicate(x));
}

var result = dict.Count(pair => Predicate(pair.Key));

Console.WriteLine(result);
