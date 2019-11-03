using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InitScript : MonoBehaviour
{
    public GameObject inputField2;
    
    public GameObject inputField;

    public GameObject buttonReg;
    // Start is called before the first frame update
    void Start()
    {
        inputField2.SetActive(false);
        buttonReg.SetActive(false);
        inputField.SetActive(false);
    }
}
