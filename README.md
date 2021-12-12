
# ROCKET LANDING LIBRARY

Landing Area 
 -  Lies on X and Y coordinates. You can specify limits of coordinates while creating LandingArea object.
    
   

```bash
    LandingArea landingArea = new(x, y);
```

Platform
- Platform locates on Landing Area. Its size and location can be configurable while creating Platform object.

```bash
Platform platform = new(size, new Coordinates(x, y));
```

You should locate platform on Landing Area with LocatePlatform method of LandingArea class.

```bash
LandingArea landingArea = new(100, 100);
Platform platform = new(10, new Coordinates(5, 5));

landingArea.LocatePlatform(platform);

```

Rocket
- Rockets can land on platform with LandingArea land method.


```bash
landingArea.Land(new Rocket(new Coordinates(7, 7)));

```

## Results
This library returns these 3 response as a result.

- OutOfPlatform
- OkForLanding
- Clash
