using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    public Data data = new Data();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            Charger();
        }
    }

    public void Sauvegarder()
    {
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
    }

    public Data GetData
    {
        get{return data;}
    }
}

[System.Serializable]
public class Data
{
    public int idStatue;

    public int IdStatue
    {
        set{idStatue = value;}
    }
}
