using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LoginPage : MonoBehaviour
{
    public InputField username;
    public InputField password;
    public Button loginB;
    public Button passwordB;
    public GameObject scen1;
    public GameObject scen2;

    void Start()
    {
        loginB.onClick.AddListener(delegate
        {
            login();
        });
    }

    private void login()
    {
        scen1.SetActive(false);
        scen2.SetActive(true);
    }
}
