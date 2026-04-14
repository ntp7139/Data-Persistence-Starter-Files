using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManageScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static ManageScene Instance;
    public string playerName;
    public float highestScore;
    public bool isLoaded = false;
    private void Awake()
    {
        if(Instance != null)
        {
            DontDestroyOnLoad(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
    }
    void Start()
    {
        isLoaded = false;
        LoadInfo();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayGame()
    {
        if (ManageScene.Instance != null)
        { 
            GameObject name = GameObject.Find("Text_name");
            if (name != null)
            {
                TextMeshProUGUI txt = name.GetComponent<TextMeshProUGUI>();
                ManageScene.Instance.playerName = txt.text;
               // Debug.Log(txt.text);
                //Debug.Log(ManageScene.Instance.playerName);
            }
            
        }
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    
    }
    public void SaveInfo()
    {
        PlayerInfoSave info = new PlayerInfoSave();
        info.name = playerName; 
        info.highestScore = highestScore;
        string json = JsonUtility.ToJson(info);
        string path = Application.persistentDataPath + "/infosave.json";
        File.WriteAllText(path, json);
        Debug.Log(path);
    }
    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/infosave.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerInfoSave info = JsonUtility.FromJson<PlayerInfoSave>(json);
            playerName = info.name;
            highestScore = info.highestScore;
            isLoaded = true;
        }
    }
    public void LoadScreen()
    {

    }
    
}
[System.Serializable]
class PlayerInfoSave
{
    public string name;
    public float highestScore;
}
