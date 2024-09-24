using UnityEngine;

public class Onboarding : MonoBehaviour
{
    [SerializeField]
    private Transform onboardingUI;
    private void Start()
    {
        onboardingUI.gameObject.SetActive(false);

        // Si c'est la première fois que le jeu est lancé
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