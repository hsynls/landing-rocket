namespace rocket_landing.Core;

public class Rocket
{
    private readonly Coordinates _coordinates;
    private const int SurroundingSpace = 1;

    public Rocket(Coordinates coordinates)
    {
        _coordinates = coordinates;
    }

    public int GetX()
    {
        return _coordinates.GetX();
    }

    public int GetY()
    {
        return _coordinates.GetY();
    }

    public bool IsInSurrounding(Rocket rocket)
    {
        var surrXBeginning = _coordinates.GetX() - SurroundingSpace;
        var surrXEnd = _coordinates.GetX() + SurroundingSpace;

        var surrYBeginning = _coordinates.GetY() - SurroundingSpace;
        var surrYEnd = _coordinates.GetY() + SurroundingSpace;

        return rocket.GetX() >= surrXBeginning && rocket.GetX() <= surrXEnd
                                               && rocket.GetY() >= surrYBeginning && rocket.GetY() <= surrYEnd;
    }
}