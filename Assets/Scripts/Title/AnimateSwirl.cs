using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AnimateSwirl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RotateImage());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator RotateImage()
    {
        while (true)
        {
            gameObject.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * 100); // change 100 to adjust rotation speed
            yield return null;
        }
    }
}
