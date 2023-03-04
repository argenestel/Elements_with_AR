using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using TMPro;
using Chemistry;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static UnityAction<int, string> _elementSelected;

    public TextAsset jsonFile;

    // Buttons Couple
    public GameObject Parent;
    public GameObject ElementButton;

    private ElementsJson _element = new ElementsJson();
    void Start()
    {
 
            _element = JsonConvert.DeserializeObject<ElementsJson>(jsonFile.text);
            for (int i = 0; i < 50; i++)
            {
                Debug.Log(_element.ElementsElements[i].Name);
                var go = Instantiate(ElementButton, Parent.transform);
                int num = (int)_element.ElementsElements[i].Number - (int)1;
                go.GetComponent<Button>().onClick.AddListener(() => _elementSelected?.Invoke(num,jsonFile.text));
                go.transform.GetChild(0).GetComponent<TMP_Text>().text = _element.ElementsElements[i].Symbol;
                go.transform.GetChild(1).GetComponent<TMP_Text>().text = _element.ElementsElements[i].Name;
                
                
            }
            
    }

    private void SetButtons(int i, string data){
        _elementSelected?.Invoke(i, data);
    }
}
