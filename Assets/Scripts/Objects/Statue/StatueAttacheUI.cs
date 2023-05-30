
using UnityEngine;

public class StatueAttacheUI : MonoBehaviour
{
    
    private Transform statue;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetX;

    private Camera mainCamera;

    void Start()
    {
        statue = transform.parent.parent;
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(statue.position);
        transform.position = new Vector3(screenPosition.x + offsetX, screenPosition.y + offsetY, screenPosition.z);
    }
}
