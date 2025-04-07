using UnityEngine;
using UnityEngine.Playables;

public class ButtonMenu : MonoBehaviour
{
    public GameObject menuUI;
    public Animator cameraAnimator;

    public void StartGame()
    {
        menuUI.SetActive(false);
        cameraAnimator.SetTrigger("PlayGame");
    }

    public void Instruction()
    {
        // Show instructions screen or panel
        Debug.Log("Instructions button clicked");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}