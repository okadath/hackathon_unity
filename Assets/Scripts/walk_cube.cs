using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk_cube : MonoBehaviour
{ 
    public float panSpeed;
     
    void Start()
    {

    }
     
    void Update()
    {
        Vector3 pos = transform.position; 
        pos.z += panSpeed * Time.deltaTime;
        transform.position = pos;

        if (transform.position.y < -20)
        {
            Destroy(gameObject);
        } 

    }
}
