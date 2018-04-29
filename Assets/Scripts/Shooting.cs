using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

    [SerializeField] ParticleSystem leftBullets;
    [SerializeField] ParticleSystem rightBullets;
    ParticleSystem.EmissionModule leftEmissionModule;
    ParticleSystem.EmissionModule rightEmissionModule;
    AudioSource soundPlayer;
    bool weaponPickedUp;

    // Use this for initialization
    void Start () {
        leftEmissionModule = leftBullets.emission;
        rightEmissionModule = rightBullets.emission;
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

    public void activateWeapon(string weapon)
    {
        if (weapon.ToLower() == "blasters")
        {
            leftEmissionModule.rateOverTime = 3.82f;
            rightEmissionModule.rateOverTime = 3.82f;
            soundPlayer.pitch = 0.9f;
        }
        else if (weapon.ToLower() == "machine blasters")
        {
            leftEmissionModule.rateOverTime = 18f;
            rightEmissionModule.rateOverTime = 18f;
            soundPlayer.pitch = 2.15f;
        }
    }
}
