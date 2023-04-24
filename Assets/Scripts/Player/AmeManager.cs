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

    void Start()
    {
        target = GameObject.Find("Player").GetComponent<Transform>();
        randomPos = Random.insideUnitCircle.normalized * maxDistance;
    }

    void Update()
    {
        
        if (Vector3.Distance(transform.position, target.position + pos + randomPos) < 0.0001f)
        {
            randomPos = Random.insideUnitCircle.normalized * maxDistance;
        }
        transform.position = Vector3.SmoothDamp(transform.position, target.position + pos + randomPos, ref velocity, timeOffset);
    }

    

}
