using UnityEngine;
using TMPro;

public class UICountSoul : MonoBehaviour
{
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = VariableGlobale.soulCount.ToString();
    }
}
