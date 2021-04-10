using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StratInitSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameEvents.current.onLogin += OnLogin;
    }

    private void OnLogin()
    {
        SceneManager.LoadScene("ChooseGameScene");
    }
}
