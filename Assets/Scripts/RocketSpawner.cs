using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private List<GameObject> spawnedRockets = new List<GameObject>();
    private GameObject selectedRocket = null;
    private Vector2 touchPosition;

    private Camera _camera;

    private void Awake()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        if (Application.isEditor)
        {
            HandleMouse();
        }
        else
        {
            HandleTouch();
        }
    }

    private void HandleTouch()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        Touch touch = Input.touches[0];
        touchPosition = touch.position;

        switch (touch.phase)
        {
            case TouchPhase.Began:
                SelectOrSpawnRocket();
                break;
            case TouchPhase.Moved:
                MoveSelectedRocket();
                break;
            case TouchPhase.Ended:
                selectedRocket = null; // Deselect the rocket when touch ends
                break;
        }
    }

    private void HandleMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchPosition = Input.mousePosition;
            SelectOrSpawnRocket();
        }
        else if (Input.GetMouseButton(0))
        {
            touchPosition = Input.mousePosition;
            MoveSelectedRocket();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            selectedRocket = null; // Deselect the rocket when mouse button is released
        }
    }

    private void SelectOrSpawnRocket()
    {
        // Check if a rocket is touched/clicked
        Ray ray = _camera.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("rocket"))
            {
                selectedRocket = hit.collider.gameObject;
                return;
            }
        }

        // If no rocket was selected, spawn a new one
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            GameObject newRocket = Instantiate(rocketPrefab, hitPose.position, hitPose.rotation);
            spawnedRockets.Add(newRocket);
            selectedRocket = newRocket; // Select the newly spawned rocket
        }
    }

    private void MoveSelectedRocket()
    {
        if (selectedRocket == null) return;

        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            selectedRocket.transform.position = hitPose.position;
        }
    }
}
