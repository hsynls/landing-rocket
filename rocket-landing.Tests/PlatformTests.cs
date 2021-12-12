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
        landingArea = new(100, 100);
        platform = new(_size, new Coordinates(5, 5));
    }

    [Test]
    public void Platform_Should_Throw_Exception_When_Added_Before()
    {
        landingArea.LocatePlatform(platform);

        Assert.Throws<PlatformAlreadyLocatedException>(() =>
            landingArea.LocatePlatform(new Platform(_size, new Coordinates(10, 10))));
    }
    
    [Test]
    public void InvalidPlatform_Should_Throw_Exception()
    {
        Platform invalidPlatform = new(_size, new Coordinates(99,99));
        
        Assert.Throws<InvalidPlatformExceptionException>(() =>
            landingArea.LocatePlatform(invalidPlatform));
    }

    [Test]
    public void Platform_Ending_Coordinate_Should_Return()
    {
        landingArea.LocatePlatform(platform);

        Assert.AreEqual(_size + platform.GetX(), platform.PlatformEndingX);
        Assert.AreEqual(_size + platform.GetY(), platform.PlatformEndingY);
    }
}