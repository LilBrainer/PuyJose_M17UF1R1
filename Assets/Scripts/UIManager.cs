using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject deathScreen;
    [SerializeField] GameObject winnerScreen;

    public void ToggleDeathScreen()
    {
        deathScreen.SetActive(!deathScreen.activeSelf);
    }

    public void ToggleWinnerScreen()
    {
        winnerScreen.SetActive(!winnerScreen.activeSelf);
    }
}
