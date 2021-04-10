using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SubmitLogin : MonoBehaviour
{
    [SerializeField] private TMP_InputField loginInputField;
    [SerializeField] private TMP_InputField passwordInputField;

    public void Submit()
    {
        Debug.Log($"username: {loginInputField.text}");
        Debug.Log($"password: {passwordInputField.text}");
        Debug.LogFormat("Fields {0} {1}", loginInputField.text, passwordInputField.text);
        GetVersion getVersion = new GameObject().AddComponent<GetVersion>();
        getVersion.Call();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
