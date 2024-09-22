using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CameraManagerScript : MonoBehaviour
{
    public ARSession arSession;
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARFaceManager arFaceManager;
    public AROcclusionManager arOcclusionManager;
    ARCameraManager arCameraManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arCameraManager = GetComponent<ARCameraManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeCameraMode()
    {
        StartCoroutine(ChangeCameraModeCoroutine());
    }

    public IEnumerator ChangeCameraModeCoroutine()
    {
        
            if (arCameraManager.currentFacingDirection == CameraFacingDirection.World)
            {
                arSession.enabled = false;
                arPlaneManager.enabled = false;
                arRaycastManager.enabled = false;
                arOcclusionManager.enabled = false;
                arFaceManager.enabled = true;
                yield return null;
                yield return null;

                arCameraManager.requestedFacingDirection = CameraFacingDirection.User;
                arSession.enabled = true;

            }
            else
            {
                arSession.enabled = false;
                arPlaneManager.enabled = true;
                arRaycastManager.enabled = true;
                arOcclusionManager.enabled = true;
                arFaceManager.enabled = false;
                GameObject.FindGameObjectsWithTag("faceTrackedItem").ToList<GameObject>().ForEach(faceTrackedItem => Destroy(faceTrackedItem));
                yield return null;
                yield return null;

                arCameraManager.requestedFacingDirection = CameraFacingDirection.World;
                arSession.enabled = true;
            }
    }
}
