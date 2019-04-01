using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginController : MonoBehaviour {
    public Button registerButton;
    public Button loginButton;
    public GameObject ob;
    public InputField UsernameIF;
    public InputField PasswordIF;
    LoginRequest loginRequest;

    private void Awake()
    {
        loginRequest = GetComponent<LoginRequest>();
    }

    public void OnLoginButton()
    {
        loginRequest.username = UsernameIF.text;
        loginRequest.password = PasswordIF.text;
        loginRequest.DefaultRequest();
    }
    public void LoadRegisterPannel()
    {
        this.gameObject.SetActive(false);
        ob.gameObject.SetActive(true);
    }

}
