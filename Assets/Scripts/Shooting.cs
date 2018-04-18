using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField] ParticleSystem leftBullets;
    [SerializeField] ParticleSystem rightBullets;
    AudioSource soundPlayer;
    bool weaponPickedUp;

    // Use this for initialization
    void Start () {
        soundPlayer = GetComponent<AudioSource>();
        weaponPickedUp = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (!Input.GetKey(KeyCode.Space) && weaponPickedUp)
        {
            leftBullets.Play();
            rightBullets.Play();
            soundPlayer.Stop();
        }
        else
        {
            if (!soundPlayer.isPlaying && weaponPickedUp)
            {
                soundPlayer.Play();
            }
        }
	}

    public void weaponWasPicked()
    {
        weaponPickedUp = true;
    }
}
