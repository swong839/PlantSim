using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

    private static bool exists = false;

    private void Awake()
    {
        if (!exists)
        {
            DontDestroyOnLoad(this.gameObject);
            exists = true;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
