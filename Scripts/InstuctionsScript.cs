using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstuctionsScript : MonoBehaviour
{
    public Text canvasText1;
    public Text canvasText2;
    public Text canvasText3;
    public Text canvasText4;
    public Text canvasText5;
    public Text canvasText6;
    public Text canvasText7;
    // Start is called before the first frame update
    void Start()
    {
        canvasText1.enabled = false;
        canvasText2.enabled = false;
        canvasText3.enabled = false;
        canvasText4.enabled = false;
        canvasText5.enabled = false;
        canvasText6.enabled = false;
        canvasText7.enabled = false;
        Invoke("EnableText", 1f);//invoke after 1 seconds
    }

    // Update is called once per frame
    void Update()
    {
        if (canvasText1.enabled == true)
        {
            Invoke("DisableText", 5f);
        }
        if (canvasText2.enabled == true)
        {
            Invoke("DisableSText", 5f);
        }
        if (canvasText3.enabled == true)
        {
            Invoke("DisableNText", 9f);
        }
        if (canvasText4.enabled == true)
        {
            Invoke("DisableHText", 4f);
        }
        if (canvasText5.enabled == true)
        {
            Invoke("Disable5Text", 5f);
        }
        if (canvasText6.enabled == true)
        {
            Invoke("DisableZText", 5f);
        }
        if (canvasText7.enabled == true)
        {
            Invoke("DisableBText", 7f);
        }
    }
    public void EnableText()
    { 
        canvasText1.enabled = true; 
    }
    public void DisableText()
    { 
        canvasText1.enabled = false; 
    }
    public void EnableSText()
    {
        canvasText2.enabled = true;
    }
    public void DisableSText()
    {
        canvasText2.enabled = false;
    }
    public void EnableNText()
    {
        canvasText3.enabled = true;
    }
    public void DisableNText()
    {
        canvasText3.enabled = false;
    }
    public void EnableHText()
    {
        canvasText4.enabled = true;
    }
    public void DisableHText()
    {
        canvasText4.enabled = false;
    }
    public void Enable5Text()
    {
        canvasText5.enabled = true;
    }
    public void Disable5Text()
    {
        canvasText5.enabled = false;
    }
    public void EnableZText()
    {
        canvasText6.enabled = true;
    }
    public void DisableZText()
    {
        canvasText6.enabled = false;
    }
    public void EnableBText()
    {
        canvasText7.enabled = true;
    }
    public void DisableBText()
    {
        canvasText7.enabled = false;
    }
}
