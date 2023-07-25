using UnityEngine;

public class StatueAfficherUI : MonoBehaviour
{
    private Sauvegarder sauvegarder;
    private GameObject statueUI;
    void Start()
    {
        sauvegarder = GetComponent<Sauvegarder>();
        statueUI = transform.GetChild(0).GetChild(0).gameObject;
    }

    void Update()
    {
        if (sauvegarder.IsReach)
        {
            statueUI.SetActive(true);
        }
        else
        {
            statueUI.SetActive(false);
        }
    }
}
