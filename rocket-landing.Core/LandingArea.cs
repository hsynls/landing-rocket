using rocket_landing.Core.Enums;
using rocket_landing.Core.Exceptions;

namespace rocket_landing.Core;

public class LandingArea
{
    private int _x { get; }
    private int _y { get; }

    private Platform _platform;

    public LandingArea(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public void LocatePlatform(Platform platform)
    {
        if (!CanLocate(platform))
            throw new PlatformAlreadyLocatedException("Platform already located!");

        _platform = platform;
    }

    private bool CanLocate(Platform platform)
    {
        if (_platform != null)
        {
            return false;
        }

        return platform.PlatformEndingX <= _x && platform.PlatformEndingY <= _y;
    }

    public LandingResults Land(Rocket rocket)
    {
        if (!InsideOfPlatform(rocket))
        {
            return LandingResults.OutOfPlatform;
        }

        return _platform.SettleRocket(rocket);
    }

    public List<LandingResults> Lands(params Rocket[] rocket)
    {
        return rocket.Select(Land).ToList();
    }

    private bool InsideOfPlatform(Rocket rocket)
    {
        return (_platform.PlatformEndingX >= rocket.GetX() &&
                _platform.PlatformEndingY >= rocket.GetY())
               && (rocket.GetX() >= _platform.GetX() && rocket.GetY() >= _platform.GetY());
    }
}