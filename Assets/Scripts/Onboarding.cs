using UnityEngine;

public class Onboarding : MonoBehaviour
{
    [SerializeField]
    private Transform onboardingUI;
    void Start()
    {
        onboardingUI.gameObject.SetActive(false);
        
        if (!PlayerPrefs.HasKey("FirstLaunch"))
        {
            PlayerPrefs.SetInt("FirstLaunch", 1);
            PlayerPrefs.Save();
            StartTutorial();
        }
    }
    
    public void StartTutorial()
    {
        onboardingUI.gameObject.SetActive(true);
    }
    
}
