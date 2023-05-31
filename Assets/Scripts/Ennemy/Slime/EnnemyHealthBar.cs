using UnityEngine;
using UnityEngine.UI;

public class EnnemyHealthBar : MonoBehaviour
{

    private Ennemi ennemy;


    private Image image;


    // Start is called before the first frame update
    void Start()
    {

        ennemy = transform.parent.parent.GetComponent<Ennemi>();
        image = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            float pourcentage = ennemy.Health / 100f;
            image.fillAmount = pourcentage;
        }
    }
}
