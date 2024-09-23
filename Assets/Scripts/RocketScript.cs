using System;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    private bool launching;
    [SerializeField] private Transform fireEffect;
    [SerializeField] private AudioClip launchSound;


    public void LaunchRocket()
    {
        launching = true;
        fireEffect.gameObject.SetActive(true);
        // Joue l'animation de lancement
        LeanTween.moveLocalY(transform.gameObject, 60, 20).setEase(LeanTweenType.easeInSine).setOnComplete(() => Destroy(gameObject));
    }
    
    public bool IsLaunching()
    {
        return launching;
    }
}