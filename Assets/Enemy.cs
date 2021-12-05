using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathVFX;
    [SerializeField] GameObject hitVfx;
    [SerializeField] Transform parent;
    [SerializeField] int ScorePerHit = 15;
    [SerializeField] int hitPoints = 2;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindObjectOfType<Scoreboard>();
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints < 1)
        {
            KillEnemy();
        }
    }

    private void KillEnemy()
    {
        GameObject vfx = Instantiate(deathVFX, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        Destroy(gameObject);
    }

    private void ProcessHit()
    {
        GameObject vfx = Instantiate(hitVfx, transform.position, Quaternion.identity);
        vfx.transform.parent = parent;
        hitPoints--;
        scoreboard.IncreaseScore(ScorePerHit);
    }
}
