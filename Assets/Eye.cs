using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Eye : MonoBehaviour
{

    public GameObject player;
    /*
    [SerializeField] private Transform targetDir;
    */
    public float angleOffset; 
    void Update()
    {
       // Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
       Vector3 targetDir = player.transform.position - transform.position;

       float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) + angleOffset;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); 

    }
}
