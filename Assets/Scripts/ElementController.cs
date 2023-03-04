using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Chemistry;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using UnityEngine.UI;

public class ElementController : MonoBehaviour
{
    private ElementsJson _elementInfo = new ElementsJson();
    public TMP_Text _text;
    public GameObject Electron;

    void OnEnable()
    {
        ButtonManager._elementSelected += elementinfo;
    }

    void Start()
    {
        
    }

    void elementinfo(int i, string data){
        _elementInfo = JsonConvert.DeserializeObject<ElementsJson>(data);
        ElementSelection(i);
    }

    private void ElementSelection(int i){
        if(_elementInfo != null){
        ColorUtility.TryParseHtmlString(_elementInfo.ElementsElements[i].CpkHex, out Color newCol);
        gameObject.GetComponent<Renderer>().material.color = newCol;
        
        var electronNumber = _elementInfo.ElementsElements[i].Shells[_elementInfo.ElementsElements[i].Shells.Length - 1]; 
        for(var y = 0; y < transform.childCount; y++){
            Destroy(transform.GetChild(y));
        }
        for(var x = 0; x < electronNumber; x++){
        // Instantiate(Electron, transform);
        
        var radians = 2 * 3.14f / electronNumber * x;
         
         /* Get the vector direction */ 
         var vertical = MathF.Sin(radians);
         var horizontal = MathF.Cos(radians); 
         
         var spawnDir = new Vector3 (horizontal, vertical, 0);
         
         /* Get the spawn position */ 
         var spawnPos = transform.position + spawnDir * transform.localScale.y; // Radius is just the distance away from the point
         
         /* Now spawn */
         var electron = Instantiate (Electron, spawnPos, Quaternion.identity, transform) as GameObject;
         
         /* Rotate the enemy to face towards player */
         electron.transform.LookAt(transform.position);
         
         /* Adjust height */
        // electron.transform.Translate (new Vector3 (0, electron.transform.localScale.y / 2, 0));
        }
        }
    }

    void OnDisable()
    {
        ButtonManager._elementSelected -= elementinfo;
    }

}
