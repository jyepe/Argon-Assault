using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Play", 5f);
	}

    private void Play()
    {
        SceneManager.LoadScene(1);
    }

    private int getCurrentLevel()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update () {
        
	}
}
