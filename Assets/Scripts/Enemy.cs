using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] int points = 100;

    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnParticleCollision(GameObject other)
    {
        score.AddScore(points);
        Instantiate(deathVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
