using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenRegDialog : MonoBehaviour
{
    private readonly Color _colorGreen = new Color(71f, 201f, 175f, 255f);

    public InputField inputEmail;

    public InputField inputLogin;

    public InputField inputPassword;
    
    public InputField inputPasswordRepeat;
    
    public Button buttonEnter;

    public Button buttonReg;

    public Button buttonReg2;

    
    
    public void OnClick()
    {
        inputEmail.placeholder.GetComponent<Text>().text = "ВВедите Email";
        inputLogin.placeholder.GetComponent<Text>().text = "ВВедите Логин";
        inputPassword.placeholder.GetComponent<Text>().text = "ВВедите пароль";
        inputPasswordRepeat.placeholder.GetComponent<Text>().text = "Повторите пароль";
        inputPassword.gameObject.SetActive(true);
        buttonReg.gameObject.SetActive(false);
        buttonReg2.gameObject.SetActive(true);
        buttonEnter.gameObject.SetActive(false);
        inputPasswordRepeat.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        buttonReg.onClick.AddListener(OnClick);
    }
    // Update is called once per frame
    void Update()
    {
        if(inputPassword.text != inputPasswordRepeat.text)
        {
            inputPassword.GetComponent<Image>().color = Color.red;
            inputPasswordRepeat.GetComponent<Image>().color = Color.red;
        }
        else
        {
            inputPassword.GetComponent<Image>().color = _colorGreen;
            inputPasswordRepeat.GetComponent<Image>().color = _colorGreen;
        }
    }
}
