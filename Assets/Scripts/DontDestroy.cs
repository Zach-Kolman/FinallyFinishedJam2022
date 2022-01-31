using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{

    public string LastLevelName = "Car 1-5";


    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if(objs.Length > 1 || (SceneManager.GetActiveScene().name == LastLevelName))
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }

}