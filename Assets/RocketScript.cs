using System;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public bool launching;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void LaunchRocket()
    {
        launching = true;
        LeanTween.moveLocalY(transform.gameObject, 60, 20).setEase(LeanTweenType.easeInSine).setOnComplete(() => Destroy(gameObject));
    }
}
