using System;

var waypoint = new Point(1, 10);
var ship = new Point(0, 0);
string? line;
while ((line = Console.ReadLine()) is not null)
{
    var action = line[0];
    var value = int.Parse(line[1..]);
    switch (action)
    {
        case 'L': waypoint = Rotate(waypoint, -value); break;
        case 'R': waypoint = Rotate(waypoint, value); break;
        case 'F': ship = new Point
            (
                Lat: ship.Lat + waypoint.Lat * value,
                Lon: ship.Lon + waypoint.Lon * value
            );
            break;
        default:
            waypoint = action switch
            {
                'N' => new Point(waypoint.Lat + value, waypoint.Lon),
                'S' => new Point(waypoint.Lat - value, waypoint.Lon),
                'E' => new Point(waypoint.Lat, waypoint.Lon + value),
                'W' => new Point(waypoint.Lat, waypoint.Lon - value),
                _ => throw new ArgumentOutOfRangeException()
            };
        break;
    }
}

Console.WriteLine(Math.Abs(ship.Lat) + Math.Abs(ship.Lon));

Point Rotate(Point point, int degrees)
{
    var rad = (Math.PI / 180) * degrees;
    var cos = (int)Math.Cos(rad);
    var sin = (int)Math.Sin(rad);
    var lat = point.Lat * cos - point.Lon * sin;
    var lon = point.Lat * sin + point.Lon * cos;
    return new Point(lat, lon);
}

record Point(int Lat, int Lon);
