namespace rocket_landing.Core;

public class Coordinates
{
    private int _x;
    private int _y;

    public Coordinates(int x, int y)
    {
        _x = x;
        _y = y;
    }

    public int GetX()
    {
        return _x;
    }

    public int GetY()
    {
        return _y;
    }
}