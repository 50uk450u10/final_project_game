using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WaveCounter
{
   public static int waveCount { get; private set; }

    public static void IncrementWave()
    {
        waveCount++;
    }

    public static void ResetWave()
    {
        waveCount = 0;
    }
}
