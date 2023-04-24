using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIcapaciteBackground : MonoBehaviour
{
    private Image image;


    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    public void UpdateImage(Sprite _icon)
    {
        image.sprite = _icon;
    }


}
