using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public float autoLoadTime = 0;

	void Start () {	
        if (autoLoadTime != 0f)
        {
            Invoke("LoadNextLevel", autoLoadTime);
        }
	}
	void Update () {	
	}

    void LoadLevel (int levelNum)
    {
        SceneManager.LoadScene(levelNum);
    }

    void LoadNextLevel ()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex + 1);
    }
}
