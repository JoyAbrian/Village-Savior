using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    public static int playerScore = 0;
    public static int playerHealth = 3;

    public static string gameState = "MainMenu";

    private void Start()
    {
        gameState = "MainMenu";
        playerScore = 0;
        playerHealth = 3;
    }
}
