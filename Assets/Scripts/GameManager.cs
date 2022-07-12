using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using TMPro;

public class GameManager : MonoBehaviour
{
    public Button[] buttons;
    public TextMeshProUGUI returnValDisplayer;
    public GameObject UnityToJsPanel;
    public GameObject JsToUnityPanel;
    public TextMeshProUGUI[] texts;


    #region DllImport

    [DllImport("__Internal")]
    private static extern void Alert();

    [DllImport("__Internal")]
    private static extern void AlertParam(string param);

    [DllImport("__Internal")]
    private static extern int GetInt();

    [DllImport("__Internal")]
    private static extern string GetString();

    #endregion

    // Start is called before the first frame update
    void Start()
    {

        buttons[0].onClick.AddListener(() => UnityCallJSFunc());
        buttons[1].onClick.AddListener(() => UnityCallJSFuncWithParam("This is function call with param"));
        buttons[2].onClick.AddListener(() => ReturnIntegerFromJS());
        buttons[3].onClick.AddListener(() => ReturnStringFromJS());
    }

    private void ReturnStringFromJS()
    {
        string val = GetString();
        returnValDisplayer.text = "Returned Value: " + val.ToString();
    }

    private void ReturnIntegerFromJS()
    {
        int val = GetInt();
        returnValDisplayer.text = "Returned Value: " + val.ToString();
    }

    private void UnityCallJSFuncWithParam(string param)
    {
        AlertParam(param);
    }

    private void UnityCallJSFunc()
    {
        Alert();
    } 


    #region JSTOUnity
    
    public void SetValueFromJS()
    {
        texts[0].text = "Value changed by JS";
    }

    public void SetValueFromJSWithParam(string param)
    {
        texts[1].text = param.ToString();
    }
    #endregion

    public void UnityToJsPanelActivate()
    {
        UnityToJsPanel.SetActive(false);
        JsToUnityPanel.SetActive(true);
    }
    public void JsToUnityPanelActivate()
    {
        UnityToJsPanel.SetActive(true);
        JsToUnityPanel.SetActive(false);
        

    }
}
