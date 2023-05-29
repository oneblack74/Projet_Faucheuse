using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcapacite : MonoBehaviour
{
    private int currentTime;
    [SerializeField] private int maxTime;

    private Image image;

    private float percentage;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();

        currentTime = maxTime;
    }

    public void UpdateImage(Sprite _icon)
    {
        image.sprite = _icon;
    }

    // Update is called once per frame
    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            percentage = (float) currentTime / maxTime;
            image.fillAmount = percentage;
        }
    }

    public int CurrentTime
    {
        set{currentTime = value;}
    }

}
