using UnityEngine;

public class ButtonMenu : MonoBehaviour
{
    public GameObject menuUI;
    public Animator cameraAnimator;
    public GameObject player;

    public void StartGame()
    {
        menuUI.SetActive(false);
        GlobalVariables.gameState = "Game";
        cameraAnimator.SetTrigger("PlayGame");
        player.GetComponent<Animator>().SetBool("isPlaying", true);
        player.GetComponent<AimController>().enabled = true;
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