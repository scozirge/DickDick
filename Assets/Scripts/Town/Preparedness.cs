using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Preparedness : MonoBehaviour
{
    [SerializeField]
    Text Text_Title;
    [SerializeField]
    Text Text_Title2;
    public void Init()
    {
        Text_Title.text = GameDictionary.String_UIDic["Preparedness_RoleSelect"].GetString(Player.UseLanguage);
        Text_Title2.text = GameDictionary.String_UIDic["BuySupplies"].GetString(Player.UseLanguage);
        gameObject.SetActive(false);
    }
    public void OnFightClick()
    {
        GameManager.ChangeScene("Dungeon");
    }
}
