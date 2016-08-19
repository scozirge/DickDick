using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Combo : MonoBehaviour
{
    [SerializeField]
    Text Text_Combo;

    public void ShowCombo(int _combo)
    {
        gameObject.SetActive(true);
        Text_Combo.text = string.Format("Combox{0}", _combo.ToString());
    }
    public void HideCombo()
    {
        gameObject.SetActive(false);
    }
}
