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
        print(other.tag);
        if (other.tag.ToLower() == "blasters")
        {
            shootingScript.activateWeapon("blasters");
            weaponPickup.playClip();
            shootingScript.weaponWasPicked();
        }
        else if (other.tag.ToLower() == "machine blasters")
        {
            shootingScript.activateWeapon("machine blasters");
            weaponPickup.playClip();
            shootingScript.weaponWasPicked();
        }
        else
        {
            SendMessage("recieveCollisionMessage", false);
            explosion.SetActive(true);
            Invoke("reloadLevel", levelDelay);
        }
    }

    private void reloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
