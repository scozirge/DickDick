using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class StopCom : MonoBehaviour
{
    StopData MyData;
    [SerializeField]
    Image Image_Icon;
    
    public void SetData(StopData _data)
    {
        MyData = _data;
        SetImage();
    }

    void SetImage()
    {
        switch(MyData.Type)
        {
            case "Enemy":
                Image_Icon.color = Color.blue;
                break;
            case "Rescue":
                Image_Icon.color = Color.cyan;
                break;
            case "Treasure":
                Image_Icon.color = Color.gray;
                break;
            case "TrapTreasure":
                Image_Icon.color = Color.green;
                break;
            case "PhysicsTrap":
                Image_Icon.color = Color.red;
                break;
            case "MagicTrap":
                Image_Icon.color = Color.yellow;
                break;
            case "LightAltar":
                Image_Icon.color = Color.magenta;
                break;
            case "ReviveAltar":
                Image_Icon.color = Color.red;
                break;
            case "Robber":
                Image_Icon.color = Color.blue;
                break;
        }
    }
}
