using System;
using System.Collections.Generic;
using Application;

public static class Helpers {

    private static Random random = new Random();

    public static void Shuffle<T>(this IList<T> list) 
    {
        int n = list.Count;
        while (n > 1) 
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static int Range(int min, int max)
    {
        return min + random.Next() % (max + 1);
    }

    public static GameType RandomGameType()
    {
        Array values = Enum.GetValues(typeof(GameType));
        Random random = new Random();
        GameType randGameType = (GameType)values.GetValue(random.Next(values.Length));
        return randGameType;
    }
}
