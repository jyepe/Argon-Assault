using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Enemy : MonoBehaviour {

    [SerializeField] private GameObject explosion;      //Explosion effect for the enemy ships
    private ScoreBoard board;                           //The score on the screen
    [Range(1,100)] [SerializeField] private int maxHits;               //The number of hits before enemy dies

	// Use this for initialization
	void Start () {
        BoxCollider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
        board = FindObjectOfType<ScoreBoard>();
	}
	
	// Update is called once per frame
	void Update () { 
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
        board.addToScore();
        Destroy(gameObject);
    }
}
