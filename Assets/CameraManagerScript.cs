using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class CameraManagerScript : MonoBehaviour
{
    public ARPlaneManager arPlaneManager;
    public ARRaycastManager arRaycastManager;
    public ARFaceManager arFaceManager;
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
        if (arCameraManager.currentFacingDirection == CameraFacingDirection.World)
        {
            arPlaneManager.enabled = false;
            arRaycastManager.enabled = false;
            arFaceManager.enabled = true;
            arCameraManager.requestedFacingDirection = CameraFacingDirection.User;
        }
        else
        {
            arPlaneManager.enabled = true;
            arRaycastManager.enabled = true;
            arFaceManager.enabled = false;
            GameObject.FindGameObjectsWithTag("faceTrackedItem").ToList<GameObject>().ForEach(faceTrackedItem => Destroy(faceTrackedItem));
            arCameraManager.requestedFacingDirection = CameraFacingDirection.World;
        }
    }
}
