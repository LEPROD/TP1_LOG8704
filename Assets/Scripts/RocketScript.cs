using System;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public bool launching;
    [SerializeField] private Transform fireEffect;
    private AudioManager _audioManager;
    [SerializeField] private AudioClip launchSound;


    public void LaunchRocket()
    {
        launching = true;
        AudioManager.Instance.PlayLaunchSound();
        fireEffect.gameObject.SetActive(true);
        LeanTween.moveLocalY(transform.gameObject, 60, 20).setEase(LeanTweenType.easeInSine).setOnComplete(() => Destroy(gameObject));
    }
}
