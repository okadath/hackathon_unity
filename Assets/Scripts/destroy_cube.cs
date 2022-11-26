using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_cube : MonoBehaviour
{
    private bool beingHandled = false;
    public int max_destroy = 0;
    public int collisioncounter = 0;
    public GameObject cube;
    public GameObject basee;
    void Start()
    {
        basee = GameObject.Find(basee.name);
    } 
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        //print("collision"+  collision.other.name);
        if (collision.other.name == cube.name+"(Clone)" || collision.other.name == basee.name )
        {
            collisioncounter++;
        }

        if (collisioncounter > max_destroy)
        {
            Destroy(gameObject);
        }

    }

     
}
