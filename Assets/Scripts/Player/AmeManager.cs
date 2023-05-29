using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmeManager : MonoBehaviour
{

    [SerializeField] private Vector3 pos;
    [SerializeField] private float timeOffset;
    [SerializeField] private float maxDistance;
    private GameObject player;

    private Transform target;
    private Vector3 velocity;
    private Vector3 randomPos;
    private int dir;
    private Vector3 newPos;

    void Start()
    {   
        player = GameObject.Find("Player");
        target = player.GetComponent<Transform>();
        randomPos = Random.insideUnitCircle.normalized * maxDistance;
        dir = player.GetComponent<PlayerMoveManager>().getDir;
    }

    void Update()
    {   
        if (!VariableGlobale.jeuEnPause)
        {
            dir = player.GetComponent<PlayerMoveManager>().getDir;
            newPos = new Vector3(pos.x*dir, pos.y, 0);
            if (Vector3.Distance(transform.position, target.position + newPos + randomPos) < 0.0001f)
            {
                randomPos = Random.insideUnitCircle.normalized * maxDistance;
            }
            transform.position = Vector3.SmoothDamp(transform.position, target.position + newPos + randomPos, ref velocity, timeOffset);
        }
    }
}
