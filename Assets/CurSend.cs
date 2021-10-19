using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CurSend : MonoBehaviour
{
    public void Send()
    {
        try
        {
            GameManager.Instance.CurMain = (MAIN)Enum.Parse(typeof(MAIN), gameObject.transform.GetChild(1).GetComponent<Text>().text);
        }
        catch
        {
            GameManager.Instance.CurSurv = (SURV)Enum.Parse(typeof(SURV), gameObject.transform.GetChild(1).GetComponent<Text>().text);
        }
        
    }
}
