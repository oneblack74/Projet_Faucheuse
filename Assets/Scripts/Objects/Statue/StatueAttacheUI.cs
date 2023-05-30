
using UnityEngine;

public class StatueAttacheUI : MonoBehaviour
{
    
    private Transform statue;
    [SerializeField] private float offsetY;
    [SerializeField] private float offsetX;

    private Camera mainCamera;

    void Start()
    {
        statue = GameObject.Find("Statue").GetComponent<Transform>();
        mainCamera = Camera.main;
    }

    
    void Update()
    {
        Vector3 screenPosition = mainCamera.WorldToScreenPoint(statue.position);
        transform.position = new Vector3(screenPosition.x + offsetX, screenPosition.y + offsetY, screenPosition.z);
    }
}
