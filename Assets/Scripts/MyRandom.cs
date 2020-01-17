using System;

public static class MyRandom
{
    private static Random rand = new Random();

    public static int RandomDirection()
    {
        var randNumber = rand.Next(0, 10);
        int direction;

        if (randNumber < 5)
            direction = 1;
        else
            direction = -1;

        return direction;
    }
}
