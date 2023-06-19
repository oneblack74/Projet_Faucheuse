using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSlime : MonoBehaviour
{

    [SerializeField] private GameObject slime;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                spawnSlime();
            }

        }
    }

    private void spawnSlime()
    {
        GameObject slimeObject = Instantiate(slime, transform.position, Quaternion.identity);
    }

}
