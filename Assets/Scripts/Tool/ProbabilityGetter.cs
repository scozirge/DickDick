using UnityEngine;
using System.Collections;

public class ProbabilityGetter
{
    public static bool GetResult(float _probability)
    {
        float randomNum = Random.Range(0, 1);
        if (randomNum > _probability)
            return false;
        else
            return true;
    }
}
