using UnityEngine;
using System.Collections;

public class StopData
{
    public string Type { get; private set; }
    public int Lv { get; private set; }
    public StopData(string _type, int _lv)
    {
        Type = _type;
        Lv = _lv;
    }
    public void GetResult(int _result)
    {
        switch (Type)
        {
            case "Enemy":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "Rescue":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "Treasure":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "TrapTreasure":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "PhysicsTrap":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "MagicTrap":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "LightAltar":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "ReviveAltar":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
            case "Robber":
                if (_result == 1)
                {
                    GameManager.ChangeScene("Battle");
                }
                else if (_result == 2)
                {
                    DungeonManager.NextStop();
                }
                break;
        }
    }
}

