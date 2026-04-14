using TMPro;
using UnityEngine;

public class LoadText : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        TMP_InputField text = gameObject.GetComponent<TMP_InputField>();
        if (ManageScene.Instance.isLoaded == true)
        {
            text.text = ManageScene.Instance.playerName;
            Debug.Log(ManageScene.Instance.playerName);
            Debug.Log(text);
            ManageScene.Instance.isLoaded = false ;
        }
        
    }
}
