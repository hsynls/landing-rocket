using NUnit.Framework;
using rocket_landing.Core;
using rocket_landing.Core.Exceptions;

namespace rocket_landing.Tests;

public class PlatformTests
{
    private LandingArea landingArea;
    private Platform platform;
    private int _size = 10;

    [SetUp]
    public void Setup()
    {
        landingArea = new((int)100, (int)100);
        platform = new(_size, (Coordinates)new Coordinates(5, 5));

        landingArea.LocatePlatform(platform);
    }

    [Test]
    public void Platform_Should_Throw_Exception_When_Added_Before()
    {
        Assert.Throws<PlatformAlreadyLocatedException>(() =>
            landingArea.LocatePlatform(new Platform(_size, new Coordinates(10, 10))));
    }

    [Test]
    public void Platform_Ending_Coordinate_Should_Return()
    {
        Assert.AreEqual(_size + platform.GetX(), platform.PlatformEndingX);
        Assert.AreEqual(_size + platform.GetY(), platform.PlatformEndingY);
    }
}