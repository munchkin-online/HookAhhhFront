using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User : MonoBehaviour
{
    private string _username;
    private string _password;
    private string _mail;
    private bool _active;
    private string _role;

    public string getUsername()
    {
        return _username;
    }

    public void setUsername(string username)
    {
        _username = username;
    }

    public string getPassword()
    {
        return _password;
    }

    public void setPassword(string password)
    {
        _password = password;
    }

    public string getMail()
    {
        return _mail;
    }

    public void setMail(string mail)
    {
        _mail = mail;
    }

    public bool getActive()
    {
        return _active;
    }

    public void setActive(bool active)
    {
        _active = active;
    }
}
