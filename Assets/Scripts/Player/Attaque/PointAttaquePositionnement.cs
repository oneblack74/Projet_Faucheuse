using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAttaquePositionnement : MonoBehaviour
{
    private Transform positionDefaut;

    private GameObject player;
    private Transform position;
    private int dir;

    void Start()
    {
        positionDefaut = transform;

        player = GameObject.Find("Player");
        position = player.GetComponent<Transform>();
    }

    public void actualiserPositionPointAttaque() {
        dir = player.GetComponent<PlayerMoveManager>().getDir;
        transform.position = new Vector3(positionDefaut.position.x * dir, positionDefaut.position.y, 0);
    }
}
