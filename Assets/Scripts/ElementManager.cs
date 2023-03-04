using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Chemistry;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using UnityEngine.UI;

public class ElementManager : MonoBehaviour
{
    private ElementsJson _elementInfo = new ElementsJson();
    public TMP_Text _text;

    void OnEnable()
    {
        ButtonManager._elementSelected += elementinfo;
    }

    void Start()
    {
        
    }

    void elementinfo(int i, string data){
        _elementInfo = JsonConvert.DeserializeObject<ElementsJson>(data);
        ColorUtility.TryParseHtmlString(_elementInfo.ElementsElements[i].CpkHex, out Color newCol);
        Debug.Log(_elementInfo.ElementsElements[i].CpkHex);
        Debug.Log(newCol);
        //gameObject.GetComponent<Renderer>().material.color = newCol;
        Debug.Log(_elementInfo.ElementsElements[i].Name);
    }

    void OnDisable()
    {
        ButtonManager._elementSelected -= elementinfo;
    }

}
