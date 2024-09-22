using System;
using UnityEngine;

public class ArrowBounce : MonoBehaviour
{

    private void OnEnable()
    {
        LeanTween.moveY(gameObject, transform.position.y + 70.0f, 1f).setEase(LeanTweenType.easeInOutQuad).setLoopPingPong().setDelay(0.5f);
    }
    
    private void OnDisable()
    {
        LeanTween.cancel(gameObject);
    }
}
