using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RocketManager : MonoBehaviour
{

    public void LaunchLastRocket()
    {
        List<RocketScript> rockets = FindObjectsByType<RocketScript>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).Where(r => !r.IsLaunching()).ToList();
        if (rockets.Count > 0)
        {
            rockets[rockets.Count - 1].LaunchRocket();
            AudioManager.instance.PlaySingleLaunchSound();
        }

    }

    public void LaunchAllRockets()
    {
        StartCoroutine(LaunchAllRocketsCoroutine());
    }

    private IEnumerator LaunchAllRocketsCoroutine()
    {
        List<RocketScript> rockets = FindObjectsByType<RocketScript>(FindObjectsInactive.Include, FindObjectsSortMode.InstanceID).Where(r => !r.IsLaunching()).ToList();
        if (rockets.Count > 0)
        {
            AudioManager.instance.PlayMultipleLaunchesSound();
        }
        foreach (RocketScript rocket in rockets)
        {
            rocket.LaunchRocket();
            // Attendre un peu avant de lancer la prochaine fusée
            yield return new WaitForSeconds(Random.Range(0.2f, 0.5f));
        }
    }
}