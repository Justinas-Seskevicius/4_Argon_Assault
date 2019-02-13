using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float nextLevelDelay = 1f;

    private void OnTriggerEnter(Collider other)
    {
        StartDeathSequence();
    }

    private void StartDeathSequence()
    {
        SendMessage("OnPlayerDeath");
        Invoke("RestartLevel", nextLevelDelay);
    }

    private void RestartLevel()     // called by string-referene
    {
        SceneManager.LoadScene(1);
    }
}
