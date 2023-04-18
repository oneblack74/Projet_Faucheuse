using UnityEngine;

[CreateAssetMenu]
public class ItemData : ScriptableObject
{
    [SerializeField] public string itemName;
    [SerializeField] public int stackMaxCount = 1;
    [SerializeField] public Sprite icon;
    [SerializeField] private Capacite capacite;
    [SerializeField] private int timerCapacite;

    public virtual Capacite getCapacite {
        get { return capacite; }
    }

    public virtual Sprite getIcon {
        get { return icon; }
    }

    public virtual int getTimerCapacite {
        get { return timerCapacite; }
    }
    
}


