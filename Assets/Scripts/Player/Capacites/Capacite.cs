using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capacite : ScriptableObject{
    // Propriétés commune à la toute les capacité

    // Méthodes communes à toutes les capacités
    public virtual void activer() {
        Debug.Log("La capacité est activée !");
    }
}
