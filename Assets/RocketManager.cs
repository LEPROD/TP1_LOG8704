using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void LaunchLastRocket()
    {
        List<RocketScript> rockets = FindObjectsByType<RocketScript>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).Where(r => !r.launching).ToList();
        if (rockets.Count > 0)
        {
            rockets[rockets.Count - 1].LaunchRocket();
        }
    }
    
    public void LaunchAllRockets()
    {
        List<RocketScript> rockets = FindObjectsByType<RocketScript>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).Where(r => !r.launching).ToList();
        foreach (RocketScript rocket in rockets)
        {
            rocket.LaunchRocket();
        }
    }
}
