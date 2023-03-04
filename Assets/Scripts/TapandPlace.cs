using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class TapandPlace : MonoBehaviour
{

    public GameObject ObjectToPlace;
    public GameObject InstantiatedObject;
    private ARRaycastManager arOrigin;
    private Pose placementPose;
    private bool placementPoseIsValid = false;
    private bool isPlaced {get; set;} = false;

    public GameObject placementIndicator;

    void Start()
    {
        arOrigin = FindObjectOfType<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlacementPose();
        UpdatePlacementIndicator();
    }

    private void UpdatePlacementIndicator()
    {
        if(placementPoseIsValid && !isPlaced){
            placementIndicator.SetActive(true);
            placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
        }
        else{
            placementIndicator.SetActive(false);
        }
    }

    private void UpdatePlacementPose()
    {
        var screenCenter = Camera.current.ViewportToScreenPoint(new Vector3(0.5f, 0.5f));
        var hits = new List<ARRaycastHit>();
        arOrigin.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.Planes);
        placementPoseIsValid = hits.Count > 0;
         if(placementPoseIsValid){
            placementPose = hits[0].pose;
            var cameraForward = Camera.current.transform.forward;
            var cameraBearing = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;
            placementPose.rotation = Quaternion.LookRotation(cameraBearing);
         }
    }

    public void PlaceObject(){
        if(placementPoseIsValid){
            var go = Instantiate(ObjectToPlace, placementPose.position, placementPose.rotation);
            InstantiatedObject = go;
            isPlaced = true;
        }
    }
    public void DestroyObject(){
        if(isPlaced){
            Destroy(InstantiatedObject);
            isPlaced = false;
        }
    }
}
