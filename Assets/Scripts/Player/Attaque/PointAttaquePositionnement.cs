using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAttaquePositionnement : MonoBehaviour
{
    private Vector3 decallageDefaut;

    private GameObject player;
    private Transform positionPlayer;
    private int dir;

    void Start()
    {
        player = GameObject.Find("Player");
        positionPlayer = player.GetComponent<Transform>();
        decallageDefaut = transform.position - positionPlayer.position;
        Debug.Log(decallageDefaut);
    }

    public void actualiserPositionPointAttaque() {
        dir = player.GetComponent<PlayerMoveManager>().getDir;
        transform.position = positionPlayer.position + new Vector3(decallageDefaut.x, decallageDefaut.y, 0) * dir;
    }
}
