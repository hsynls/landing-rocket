using rocket_landing.Core.Enums;

namespace rocket_landing.Core;

public class Platform
{
    private readonly Coordinates _coordinates;
    private int _size;
    private List<Rocket> _landedRockets;

    public int PlatformEndingX => _coordinates.GetX() + _size;
    public int PlatformEndingY => _coordinates.GetY() + _size;

    public Platform(int size, Coordinates landingCoordinates)
    {
        _size = size;
        _coordinates = landingCoordinates;
        _landedRockets = new List<Rocket>();
    }

    public int GetX()
    {
        return _coordinates.GetX();
    }

    public int GetY()
    {
        return _coordinates.GetY();
    }

    public LandingResults SettleRocket(Rocket rocket)
    {
        if (IsLandedBefore(rocket))
        {
            return LandingResults.Clash;
        }

        if (_landedRockets.Any() && _landedRockets.LastOrDefault()!.IsInSurrounding(rocket))
        {
            return LandingResults.Clash;
        }

        _landedRockets.Add(rocket);
        return LandingResults.OkForLanding;
    }

    private bool IsLandedBefore(Rocket rocket)
    {
        return _landedRockets.Any() &&
               _landedRockets.LastOrDefault()!.GetX().Equals(rocket.GetX()) &&
               _landedRockets.LastOrDefault()!.GetY().Equals(rocket.GetY());
    }
}