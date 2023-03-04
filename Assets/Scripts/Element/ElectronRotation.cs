using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronRotation : MonoBehaviour
{

    private GameObject target;
    [SerializeField] private float degreesPerSecond = 45;

    public void Start()
    {
        target = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, Vector3.forward, degreesPerSecond * Time.deltaTime);
    }
}