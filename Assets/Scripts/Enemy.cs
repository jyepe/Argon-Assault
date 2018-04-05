using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject explosion;
    ScoreBoard board;

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
        Instantiate(explosion, transform.position, Quaternion.identity);
        board.addToScore();
        Destroy(gameObject);
    }
}
