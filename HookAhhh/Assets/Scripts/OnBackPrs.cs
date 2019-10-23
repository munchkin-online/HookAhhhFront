﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBackPrs : MonoBehaviour
{
    static public bool _isBackPressed = false;
    
    public InputField inputEmail;

    public InputField inputPassword;

    public InputField nonUseInputField_1;
    
    public InputField nonUseInputField_2;
    
    public Button buttonEnter;

    public Button buttonReg;

    public Button nonUseButtonReg2;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (_isBackPressed == true)
            {
                Application.Quit();
                _isBackPressed = false;
            }
            else if (_isBackPressed == false)
            {
                _isBackPressed = true;
                inputEmail.text = "";
                inputPassword.text = "";
                inputEmail.placeholder.GetComponent<Text>().text = "Логин или email";
                inputPassword.placeholder.GetComponent<Text>().text = "Пароль";
                buttonEnter.gameObject.SetActive(true);
                nonUseInputField_1.gameObject.SetActive(false);
                nonUseInputField_2.gameObject.SetActive(false);
                nonUseButtonReg2.gameObject.SetActive(false);
            }
        }
    }
}
