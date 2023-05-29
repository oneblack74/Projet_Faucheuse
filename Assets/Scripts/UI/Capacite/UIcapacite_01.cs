using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcapacite_01 : MonoBehaviour
{
    [SerializeField] private int currentTime;
    [SerializeField] private int maxTime;

    private float percentage;

    Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        currentTime = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            percentage = (float) currentTime / maxTime;
            //percentage = (float) maxTime / currentTime;
            image.fillAmount = percentage;
        }
    }

    public int CurrentTime
    {
        set
        {
            currentTime = value;
        }
    }

}
