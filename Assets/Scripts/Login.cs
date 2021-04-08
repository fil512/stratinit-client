using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Login : MonoBehaviour
{
    private Label loginLabel;
    private Button submitButton;

    private int count;
    
    void onEnable()
    {
        Debug.Log("Enable");
    }

    private void IncrementCounter()
    {
            count++;
            Debug.Log($"Count {count}");
            loginLabel.text = $"Count: {count}";
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        var rootVisualElement = GetComponent<UIDocument>().rootVisualElement;
        loginLabel = rootVisualElement.Q<Label>("login-label");
        submitButton = rootVisualElement.Q<Button>("submit");
        
        submitButton.RegisterCallback<ClickEvent>(ev => IncrementCounter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
