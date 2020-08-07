using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EQ/ Player EQ")]
public class PlayerEquipement : ScriptableObject
{
    public Item equiped;
    public Transform PlayerTransform { get; set; }
    public ItemWorld itemPrefab;
    public UnityEvent onItemSwitch;


    private void OnDisable()
    {
        equiped = null;
    }

    public Item Equiped(Item item)
    {
        var dropItem = equiped;
        if (item.consumeable)
        {
            item.onEquiped?.Invoke();
            return null;
        }
        equiped = item;
        item.onEquiped?.Invoke();
        onItemSwitch?.Invoke();
        
        if(dropItem != null)
        {
            dropItem.onUnequiped?.Invoke();
        }

        return dropItem;
    }

    public void Unequiped()
    {
        if (equiped != null)
        {
            var instance = Instantiate(itemPrefab);
            instance.SetItem(equiped);
            equiped.onUnequiped?.Invoke();
        }
    }

    public void Clear()
    {
        equiped = null;
    }
}
