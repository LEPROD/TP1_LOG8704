using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RocketSpawner : MonoBehaviour
{
    [SerializeField] private GameObject rocketPrefab;
    [SerializeField] private ARRaycastManager arRaycastManager;
    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    private GameObject selectedRocket = null;
    private Vector2 touchPosition;
    private Camera cam;

    private void Awake()
    {
        cam = Camera.main;
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
                selectedRocket = null; // Deselectionne la fusée quand le doigt est relâché
                break;
        }
    }

    // Permet de lancer des fusées depuis l'éditeur Unity
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
            selectedRocket = null; // Deselectionne la fusée quand le bouton de la souris est relâché
        }
    }

    private void SelectOrSpawnRocket()
    {
        // Vérifie si une fusée est selectionnée, donc touchée avec le doigt
        Ray ray = cam.ScreenPointToRay(touchPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.CompareTag("rocket"))
            {
                selectedRocket = hit.collider.gameObject;
                return;
            }
        }

        // Si aucune fusée n'est selectionnée on en crée une nouvelle
        if (arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            GameObject newRocket = Instantiate(rocketPrefab, hitPose.position, hitPose.rotation);
            selectedRocket = newRocket; // Selectionne la fusée nouvellement créée
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