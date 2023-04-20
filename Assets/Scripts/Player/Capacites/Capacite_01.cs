//Script d'Axel

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Capacites/01", fileName = "Capacite")]
public class Capacite_01 : Capacite
{
    [SerializeField] private GameObject fauxPrefab;
    [SerializeField] private float fauxSpeed = 10f;
    private PlayerMoveManager player;
    private Transform playerTransform;

    public override void activer()
    {

        player = GameObject.FindWithTag("Player").GetComponent<PlayerMoveManager>();
        playerTransform = GameObject.FindWithTag("Player").GetComponent<Transform>();


        // Créer une instance de l'objet faux à partir du prefab
        GameObject faux = Instantiate(fauxPrefab, playerTransform.transform.position, Quaternion.identity);


        // Déplacer l'objet faux dans la direction donnée
        faux.GetComponent<Rigidbody2D>().velocity = new Vector3(player.dir, 0, 0) * fauxSpeed;

    }
}
