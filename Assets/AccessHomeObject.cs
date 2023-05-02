using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AccessHomeObject : MonoBehaviour
{
    public static GameObject specialLevelLoader;
    public GameObject levelLoader;
    void Start()
    {
        AccessHomeObject manager = GameObject.FindObjectOfType<AccessHomeObject>();
        manager.SetMyObject(levelLoader);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMyObject(GameObject obj)
    {
        specialLevelLoader = obj; 
    }
}
