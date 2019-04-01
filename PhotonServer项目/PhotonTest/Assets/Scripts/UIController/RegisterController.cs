using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterController : MonoBehaviour {
    public Button registerButton;
    public Button backLogin;
    public GameObject ob;
    private RegisterRequest registerRequest;
    public InputField usernameIF;
    public InputField passwordIF;

    private void Awake()
    {
        registerRequest = GetComponent<RegisterRequest>();
    }

    public void OnRegisterButton ()
    {
        registerRequest.username = usernameIF.text;
        registerRequest.password = passwordIF.text;
        registerRequest.DefaultRequest();
    }

    public void BackLogin()
    {
        this.gameObject.SetActive(false);
        ob.gameObject.SetActive(true);
    }
        

        
	
}
