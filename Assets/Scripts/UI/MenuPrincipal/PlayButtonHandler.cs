using UnityEngine;


public class PlayButtonHandler : MonoBehaviour
{
    public void OnPlayButtonClicked()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.StartCoroutine(GameManager.instance.LoadGameSceneAsync());
        }
        else
        {
            Debug.LogError("GameManager instance not found!");
        }
    }
}
