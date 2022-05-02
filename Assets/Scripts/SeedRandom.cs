using System;

public class SeedRandom
{
    System.Random random;

    public SeedRandom()
    {
        random = new System.Random(DateTime.Now.Millisecond.ToString().GetHashCode());
    }

    public SeedRandom(int _seed)
    {
        random = new System.Random(_seed);
    }

    public int Number(int _minInclusive, int _maxExclusive)
    {
        return random.Next(_minInclusive, _maxExclusive);
    }

    public bool Boolean()
    {
        return Number(0, 2) == 0;
    }
}