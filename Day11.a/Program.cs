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

int changes;
do
{
    changes = 0;
    var newSeats = new Dictionary<Seat, bool>(seats);
    foreach (var (seat, status) in seats)
    {
        int occupied = CountOccupiedAdjacent(seat);

        if (status && occupied >= 4)
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

int CountOccupiedAdjacent(Seat seat)
{
    int count = 0;

    for (int x = -1; x <= 1; x++)
        for (int y = -1; y <= 1; y++)
            if (x != y || x != 0)
                if (seats.TryGetValue(new Seat(seat.X + x, seat.Y + y), out var status) && status)
                    count++;

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
