using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyPath : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Transform[] path;

    private Transform target;
    private int dest = 0;

    // Start is called before the first frame update
    void Start()
    {
        target = path[0];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);

        //Si on atteint quasiment la dest, on change de target
        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            dest = (dest + 1) % path.Length;
            target = path[dest];
        }
    }
}
