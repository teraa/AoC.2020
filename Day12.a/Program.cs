using System;

const string directions = "NESW";
int dir = 1;
(int lat, int lon) ship = (0, 0);
string? line;
while ((line = Console.ReadLine()) is not null)
{
    char action = line[0];
    var value = int.Parse(line[1..]);
    switch (action)
    {
        case 'L':
            dir = (dir + 4 - value / 90) % 4;
            break;
        case 'R':
            dir = (dir + value / 90) % 4;
            break;
        case 'F':
            action = directions[dir];
            goto default;
        default:
            ship = action switch
            {
                'N' => (ship.lat + value, ship.lon),
                'S' => (ship.lat - value, ship.lon),
                'E' => (ship.lat, ship.lon + value),
                'W' => (ship.lat, ship.lon - value),
                _ => throw new ArgumentOutOfRangeException()
            };
        break;
    }
}

Console.WriteLine(Math.Abs(ship.lat) + Math.Abs(ship.lon));
