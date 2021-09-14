using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameManager : MonoBehaviour
{
  public static GameManager Instance;
  
  public int highScore;
  public string playerName;

  private void Awake()
  {
    if (Instance != null)
    {
      Destroy(gameObject);
      return;
    }
    Instance = this;
    DontDestroyOnLoad(gameObject);
    Load();
  }


  public void Save()
  {
    SaveData data = new SaveData();
    data.Score = highScore;
    data.Name = playerName;

    string json = JsonUtility.ToJson(data);

    File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
  }

  public void Load()
  {
    string path = Application.persistentDataPath + "/savefile.json";
    if (File.Exists(path))
    {
      string json = File.ReadAllText(path);
      SaveData data = JsonUtility.FromJson<SaveData>(json);

      highScore = data.Score;
      playerName = data.Name;
    }
  }

  [System.Serializable]
  class SaveData
  {
    public int Score;
    public string Name;
  }
}
