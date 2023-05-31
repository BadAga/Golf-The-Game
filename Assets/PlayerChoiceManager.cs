using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerChoiceManager : MonoBehaviour
{

    public static int NumberOfPlayers = 1;

    public void SetNumberOfPlayers(int numberOfPlayers)
    {
        PlayerChoiceManager.NumberOfPlayers = numberOfPlayers;
        PlayerPrefs.SetInt("NumberOfPlayers", numberOfPlayers);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
}
