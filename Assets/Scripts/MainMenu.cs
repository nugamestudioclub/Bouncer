using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private Button start;
    [SerializeField]
    private TMP_InputField usernameInput;
    private string username;

    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(StartClicked);
    }

    void StartClicked()
    {
        username = usernameInput.text;
        PlayerPrefs.SetString("name", username);
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
