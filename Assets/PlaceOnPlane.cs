using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using System;

public class PlaceOnPlane : MonoBehaviour
{
    //private ARSessionOrigin sessionOrigin;
    protected ARRaycastManager m_RaycastManager;
    private List<ARRaycastHit>hits;

    public GameObject model;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start() 
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
        hits = new List<ARRaycastHit>();

        model.SetActive(false);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount == 0)
           return;

        Touch touch = Input.GetTouch(0);

        if(m_RaycastManager.Raycast(touch.position,hits,UnityEngine.Experimental.XR.PlaneWithinPolygon))  
        {   
           Pose pose = hits[0].pose;

           if(!model.activeInHierarchy)
           {
               model.SetActive(true);
               model.transform.position = pose.position;
               model.transform.rotation = pose.rotation;

               canvas.SetActive(true);
           }
           else
           {
               model.transform.position = pose.position;
           }
        }   
    }
}
 