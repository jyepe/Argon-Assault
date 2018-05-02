using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour {

    [SerializeField] private GameObject explosion;      //Explosion effect for the enemy ships
    private ScoreBoard board;                           //The score on the screen
    [Range(1,100)] [SerializeField] private int maxHits;               //The number of hits before enemy dies
    BoxCollider enemyCollider;
    String enemy;

    // Use this for initialization
    void Start () {
        enemy = gameObject.name.ToLower();
        enemyCollider = gameObject.AddComponent<BoxCollider>();
        checkObject();
        enemyCollider.isTrigger = false;
        board = FindObjectOfType<ScoreBoard>();
	}

    //If its an asteroid object change the box collider dimensions
    private void checkObject()
    {
        if (enemy == "asteroid")
        {
            enemyCollider.size = new Vector3(1.69f, 1, 1.38f);
        }
    }

    private void OnParticleCollision(GameObject other)
    {
        if (other.name == "Right Laser Bullets")
        {
            maxHits--;
            shouldKill();
        }
    }

    private void shouldKill()
    {
        if (maxHits <= 0)
        {
            killEnemy();
        }
    }

    //Destroys enemy ship
    private void killEnemy()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        addPoints();
        Destroy(gameObject);
    }

    private void addPoints()
    {
        if (enemy == "asteroid")
        {
            board.addToScore(25);
        }
        else if (enemy == "")
        {

        }
        else
        {
            board.addToScore(10);
        }
    }
}
