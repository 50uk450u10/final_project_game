using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DifficultyManager 
{
    public static float difficultyMultiplier { get; private set; }

    public static void SetDifficulty(int choice)
    {
        if (choice == 1)
        {
            difficultyMultiplier = 0.5f;
        }

        else if (choice == 2)
        {
            difficultyMultiplier = 0.75f;
        }

        else if (choice == 3)
        {
            difficultyMultiplier = 1f;
        }
    }
}
