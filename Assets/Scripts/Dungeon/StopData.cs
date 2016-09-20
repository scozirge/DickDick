using UnityEngine;
using System.Collections;

public class StopData
{
    public string Type { get; private set; }
    public StopData()
    {
        Type = "Encounter";
    }
    public void GetResult(int _result)
    {
        switch (Type)
        {
            case "Encounter":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                    Debug.Log("戰鬥");
                }

                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                    Debug.Log("放棄");
                }
                break;
        }
    }
}

