using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    public void ElementPanel(){
        if(panel.transform.localScale == new Vector3(0,0,0)){
            panel.transform.DOScale(1, 0.3f);
        }
        else
        {
            panel.transform.DOScale(0, 0.3f);
        }
    }
}
