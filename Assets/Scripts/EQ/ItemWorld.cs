using UnityEngine;

public class ItemWorld : MonoBehaviour
{
    public Item item;
    public SpriteRenderer itemRenderer;
    public PlayerEquipement playerEquipement;


    private void Start()
    {
        itemRenderer.sprite = item.icon;
    }

    public void Equpie()
    {
        SetItem(playerEquipement.Equiped(item));
    }

    public void SetItem(Item item)
    {
        this.item = item;
        if(item == null)
        {
            gameObject.SetActive(false);
            return;
        }
        itemRenderer.sprite = item.icon;
    }

    public void RespawnItem(Item item)
    {
        if (playerEquipement.equiped == item)
        {
            SetItem(null);
            return;
        }
        SetItem(item);
        gameObject.SetActive(true);
    }
}
