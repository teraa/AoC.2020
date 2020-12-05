using System;
using System.Collections.Generic;

const long WantedSum = 2020;

var expenses = new List<long>();
string? line;
while ((line = Console.ReadLine()) is not null)
    expenses.Add(long.Parse(line));

for (int i = 0; i < expenses.Count - 2; i++)
{
    for (int j = i + 1; j < expenses.Count - 1; j++)
    {
        for (int k = j + 1; k < expenses.Count; k++)
        {
            if (expenses[i] + expenses[j] + expenses[k] == WantedSum)
            {
                Console.WriteLine(expenses[i] * expenses[j] * expenses[k]);
                break;
            }
        }
    }
}
