using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour {

    [SerializeField] GameObject explosion;
    [SerializeField] GameObject playerShip;
    [SerializeField] float levelDelay;
    PickupRotation weaponPickup;
    Shooting shootingScript;

	// Use this for initialization
	void Start () {
        weaponPickup = FindObjectOfType<PickupRotation>();
        shootingScript = FindObjectOfType<Shooting>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.ToLower() != "blasters")
        {
            SendMessage("recieveCollisionMessage", false);
            explosion.SetActive(true);
            Invoke("reloadLevel", levelDelay);
        }
        else
        {
            //SendMessage("activateWeapon", "Blaster");
            weaponPickup.playClip();
            shootingScript.weaponWasPicked();
        }
    }

    private void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
