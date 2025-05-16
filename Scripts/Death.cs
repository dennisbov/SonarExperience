using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private int sceneNumber;
    [SerializeField] private CurrentPlayerScoreInfo currentPlayerScoreInfo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.TryGetComponent<EnergyCounter>(out EnergyCounter e))
        {
            currentPlayerScoreInfo.deathPosition = transform.position;
            SceneManager.LoadScene(sceneNumber);
        }
    }
}
