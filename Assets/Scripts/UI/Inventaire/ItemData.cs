using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public int stackMaxCount = 1;
    [SerializeField] public Sprite icon;
    [SerializeField] private Capacite capacite;

    public virtual Capacite getCapacite {
        get { return capacite; }
    }
    
}


