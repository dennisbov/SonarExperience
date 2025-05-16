using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuTransmitir : MonoBehaviour
{
    public void GoToNextScene(int number)
    {
        SceneManager.LoadScene(number);
    }
}
