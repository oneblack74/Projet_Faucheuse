using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Data data = new Data();



    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            //Charger();
            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            gameManager.OnPlayButtonClicked();
        }
    }

    public void Sauvegarder()
    {
        SauvegarderElements();

        string saveData = JsonUtility.ToJson(data);
        string chemin = Application.persistentDataPath + "/SaveData.json";
        Debug.Log(chemin);

        System.IO.File.WriteAllText(chemin, saveData);
    }

    public void Charger()
    {
        string chemin = Application.persistentDataPath + "/SaveData.json";
        string saveData = System.IO.File.ReadAllText(chemin);

        data = JsonUtility.FromJson<Data>(saveData);
        PlacerJoueurSurStatue();
        ChargerElements();
    }

    public Data GetData
    {
        get{return data;}
    }

    public void PlacerJoueurSurStatue()
    {
        GameObject joueur = GameObject.FindWithTag("Player");
        if (joueur != null)
        {
            // Récupérer les coordonnées de la statue en utilisant l'ID sauvegardé
            Vector3 coordonneesStatue = GetCoordonneesStatue(data.IdStatue);

            // Déplacer le joueur aux coordonnées de la statue
            joueur.transform.position = coordonneesStatue;
        }
    }

    private Vector3 GetCoordonneesStatue(int _id)
    {
        GameObject[] statues = GameObject.FindGameObjectsWithTag("Statue");

        foreach (GameObject statue in statues)
        {
            Sauvegarder statueData = statue.GetComponent<Sauvegarder>();
            if (statueData != null && statueData.IdStatue == _id)
            {
                return statue.transform.position;
            }
        }

        // Si aucune statue avec l'ID donné n'est trouvée, retourner une position par défaut ou gérer l'absence de statue selon votre logique
        return Vector3.zero;
    }

    public void SauvegarderElements()
    {
        GameObject joueur = GameObject.FindWithTag("Player");

        PlayerHealth playerHealth = joueur.GetComponent<PlayerHealth>();

        data.HealthPlayer = playerHealth.Health;
        data.MaxHealthPlayer = playerHealth.MaxHealth;
        data.SoulCount = VariableGlobale.soulCount;
    }

    public void ChargerElements()
    {
        GameObject joueur = GameObject.FindWithTag("Player");

        PlayerHealth playerHealth = joueur.GetComponent<PlayerHealth>();
        playerHealth.Health = data.HealthPlayer;
        playerHealth.MaxHealth = data.MaxHealthPlayer;
        playerHealth.UpdateHealth();
        VariableGlobale.soulCount = data.SoulCount;
        
    }

}

[System.Serializable]
public class Data
{
    [SerializeField] private int idStatue;
    [SerializeField] private float maxHealthPlayer;
    [SerializeField] private float healthPlayer;
    [SerializeField] private int soulCount; 

    public int IdStatue
    {   
        get{return idStatue;}
        set{idStatue = value;}
    }

    public float MaxHealthPlayer
    {
        get{return maxHealthPlayer;}
        set{maxHealthPlayer = value;}
    }

    public float HealthPlayer
    {
        get{return healthPlayer;}
        set{healthPlayer = value;}
    }

    public int SoulCount
    {   
        get{return soulCount;}
        set{soulCount = value;}
    }
}
