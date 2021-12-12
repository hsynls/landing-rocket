using rocket_landing.Core;

LandingArea landingArea = new(100, 100);
Platform platform = new(10, new Coordinates(5, 5));

landingArea.LocatePlatform(platform);

var landing = landingArea.Land(new Rocket(new Coordinates(7, 7)));
var landing2 = landingArea.Land(new Rocket(new Coordinates(7, 8)));
var landing3 = landingArea.Land(new Rocket(new Coordinates(6, 7)));
var landing4 = landingArea.Land(new Rocket(new Coordinates(6, 6)));

Console.WriteLine($"{landing},{landing2},{landing3},{landing4}");