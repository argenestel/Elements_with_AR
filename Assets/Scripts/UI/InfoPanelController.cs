using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using TMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

using Chemistry;
public class InfoPanelController : MonoBehaviour
{
    public GameObject panel;
    private bool isMoved;
    [SerializeField] private TMP_Text _headers;
    [SerializeField] private TMP_Text _infoBody;

    private ElementsJson _elementJson = new ElementsJson(); 

    void OnEnable()
    {
        ButtonManager._elementSelected += PanelInfo;
    }

    private void PanelInfo(int elementNum, string jsonData)
    {
        _elementJson = JsonConvert.DeserializeObject<ElementsJson>(jsonData);

        _headers.text = _elementJson.ElementsElements[elementNum].Name + " ("+ _elementJson.ElementsElements[elementNum].Symbol +")";
        _infoBody.text = _elementJson.ElementsElements[elementNum].Summary;
    }

    public void Start(){
        panel.transform.DOLocalMoveX(-500, 0.02f);
        isMoved = true;
    }
    public void ElementPanel(){
        if(isMoved){
           panel.transform.DOLocalMoveX(0, 0.5f);
           isMoved = false;
        }
        else
        {
            panel.transform.DOLocalMoveX(-500, 0.5f);
            isMoved = true;
        }
    }
}
