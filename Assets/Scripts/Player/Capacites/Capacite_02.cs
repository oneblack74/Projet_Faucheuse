//Script d'Axel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Capacites/02", fileName = "Capacite")]
public class Capacite_02 : Capacite
{
    public override void activer()
    {
        VariableGlobale.soulCount++;
    }
}
