using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EQView : MonoBehaviour
{
    public PlayerEquipement EQ;
    public Image itemIcon;
    public TextMeshProUGUI itemName;
    public TextMeshProUGUI itemDescription;


    private void OnEnable()
    {
        UpdateView();
    }

    public void UpdateView()
    {
        if (EQ.equiped != null)
        {
            itemIcon.color = Color.white;
            itemIcon.sprite = EQ.equiped.icon;
            itemName.text = EQ.equiped.name;
            itemDescription.text = EQ.equiped.description;
        }
        else
        {
            itemIcon.color = new Color(0, 0, 0, 0);
            itemIcon.sprite = null;
            itemName.text = "";
            itemDescription.text = "";
        }
    }
}
