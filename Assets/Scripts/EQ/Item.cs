using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "EQ/ Item")]
public class Item : ScriptableObject
{
    public bool consumeable;
    public Sprite icon;
    new public string name;
    public string description;
    public UnityEvent onEquiped;
    public UnityEvent onUnequiped;
}
