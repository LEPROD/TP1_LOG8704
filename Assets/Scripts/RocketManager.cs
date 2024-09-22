using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketManager : MonoBehaviour
{

    public void LaunchLastRocket()
    {
        List<RocketScript> rockets = FindObjectsByType<RocketScript>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).Where(r => !r.launching).ToList();
        if (rockets.Count > 0)
        {
            rockets[rockets.Count - 1].LaunchRocket();
            AudioManager.Instance.PlaySingleLaunchSound();
        }

    }
    
    public void LaunchAllRockets()
    {
        StartCoroutine(LaunchAllRocketsCoroutine());
    }
    
    private IEnumerator LaunchAllRocketsCoroutine()
    {
        List<RocketScript> rockets = FindObjectsByType<RocketScript>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).Where(r => !r.launching).ToList();
        if (rockets.Count > 0)
        {
            AudioManager.Instance.PlayMultipleLaunchesSound();
        }
        foreach (RocketScript rocket in rockets)
        {
            rocket.LaunchRocket();
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}
