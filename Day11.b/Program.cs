using System;
using System.Collections.Generic;

var seats = new Dictionary<Seat, bool>();
string? line;
int x = 0;
int y = 0;
while ((line = Console.ReadLine()) is not null)
{
    for (y = 0; y < line.Length; y++)
        if (line[y] == 'L')
            seats[new Seat(x, y)] = false;

    x++;
}

(int x, int y) max = (x, y);

int changes;
do
{
    changes = 0;
    var newSeats = new Dictionary<Seat, bool>(seats);
    foreach (var (seat, status) in seats)
    {
        int occupied = CountOccupiedVisible(seat);

        if (status && occupied >= 5)
        {
            newSeats[seat] = false;
            changes++;
        }
        else if (!status && occupied == 0)
        {
            newSeats[seat] = true;
            changes++;
        }
    }
    seats = newSeats;
} while (changes > 0);

Console.WriteLine(CountOccupied());

int CountOccupiedVisible(Seat seat)
{
    int count = 0;

    for (int x = -1; x <= 1; x++)
    {
        for (int y = -1; y <= 1; y++)
        {
            if (x == y && x == 0) continue;

            Seat target = seat;
            do
            {
                target = new Seat(target.X + x, target.Y + y);
                if (seats.TryGetValue(target, out var status))
                {
                    if (status) count++;
                    break;
                }
            } while (target.X < max.x && target.Y < max.y && target.X >= 0 && target.Y >= 0);
        }
    }

    return count;
}

int CountOccupied()
{
    int count = 0;
    foreach (var (seat, status) in seats)
        if (status) count++;

    return count;
}

record Seat(int X, int Y);
