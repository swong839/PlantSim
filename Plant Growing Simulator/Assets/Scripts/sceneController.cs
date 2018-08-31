using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneController : MonoBehaviour {

    string selfScene;

	// Use this for initialization
	void Start () {
        selfScene = SceneManager.GetActiveScene().name;
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(selfScene);
        }
    }

    public void GoToScene(string name)
    {
        SceneManager.LoadScene(name);
    }

}
