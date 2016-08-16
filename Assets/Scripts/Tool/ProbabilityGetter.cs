using UnityEngine;
using System.Collections;

public class ProbabilityGetter
{
    public static bool GetResult(float _probability)
    {
        int randomNum = Random.Range(0, 100);
        if (randomNum > Mathf.RoundToInt(_probability * 100))
            return false;
        else
            return true;
    }
}
