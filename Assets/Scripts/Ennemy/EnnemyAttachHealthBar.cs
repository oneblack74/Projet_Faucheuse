using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyAttachHealthBar : MonoBehaviour
{
    private Transform enemy;
    [SerializeField] private float offsetY = 1f;

    private Camera mainCamera;
    
    void Start()
    {
        enemy = GameObject.Find("EnnemyTestGraphics").GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        if (!VariableGlobale.jeuEnPause)
        {
            // Convertir la position de l'ennemi en position de l'écran
            Vector3 screenPosition = mainCamera.WorldToScreenPoint(enemy.position);

            // Déplacer la barre de vie au-dessus de l'ennemi avec un décalage vertical
            transform.position = new Vector3(screenPosition.x, screenPosition.y + offsetY, screenPosition.z);
        }
    }
}
