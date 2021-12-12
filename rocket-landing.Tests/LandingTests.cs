using System.Linq;
using NUnit.Framework;
using rocket_landing.Core;
using rocket_landing.Core.Enums;

namespace rocket_landing.Tests;

public class LandingTests
{
    private LandingArea landingArea;
    private Platform platform;

    [SetUp]
    public void Setup()
    {
        landingArea = new(100, 100);
        platform = new(10, new Coordinates(5, 5));

        landingArea.LocatePlatform(platform);
    }

    [Test]
    public void Rocket_Should_Land_Inside_Of_Platform()
    {
        var landing = landingArea.Land(new Rocket(new Coordinates(15, 16)));

        Assert.AreEqual(LandingResults.OutOfPlatform, landing);
    }

    [Test]
    public void Rocket_Should_Clash_When_Last_Landed_Rocket_Land_Same_Location_Before()
    {
        var landing = landingArea.Land(new Rocket(new Coordinates(9, 9)));
        var landing2 = landingArea.Land(new Rocket(new Coordinates(9, 9)));

        Assert.AreEqual(LandingResults.Clash, landing2);
    }

    [Test]
    public void Rocket_Should_OkForLanding_When_Last_Landed_Rocket_Land_Different_Location()
    {
        var landing = landingArea.Land(new Rocket(new Coordinates(9, 9)));
        var landing2 = landingArea.Land(new Rocket(new Coordinates(6, 7)));
        var landing3 = landingArea.Land(new Rocket(new Coordinates(9, 9)));

        Assert.AreEqual(LandingResults.OkForLanding, landing3);
    }


    [Test]
    public void Rocket_Should_Clash_When_Surrounding()
    {
        var landing = landingArea.Land(new Rocket(new Coordinates(7, 7)));
        var landing2 = landingArea.Land(new Rocket(new Coordinates(7, 8)));
        var landing3 = landingArea.Land(new Rocket(new Coordinates(6, 7)));
        var landing4 = landingArea.Land(new Rocket(new Coordinates(6, 6)));

        Assert.AreEqual(LandingResults.OkForLanding, landing);
        Assert.AreEqual(LandingResults.Clash, landing2);
        Assert.AreEqual(LandingResults.Clash, landing3);
        Assert.AreEqual(LandingResults.Clash, landing4);
    }

    [Test]
    public void Multiple_Rocket_Should_Land_At_The_Same_Time()
    {
        var landings = landingArea.Lands(new Rocket(new Coordinates(7, 7)), new Rocket(new Coordinates(7, 7)));

        Assert.AreEqual(LandingResults.OkForLanding, landings.First());
        Assert.AreEqual(LandingResults.Clash, landings.Last());
    }
}