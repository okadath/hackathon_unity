using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_enemies : MonoBehaviour
{
    public Object spawn;
    private bool beingHandled = false;
    public float min_spawn;
    public float max_spawn;
    void Start()
    {


    }
     
    void Update()
    {
        if (  !beingHandled)
        {
            StartCoroutine(Coroutine_spawn_enemies());
        }
    }


    IEnumerator  Coroutine_spawn_enemies( )
    {
        beingHandled = true;
 
        yield return new WaitForSeconds(Random.Range(min_spawn, max_spawn));
        //GameObject ave_nueva = 

 
            Instantiate(spawn, new Vector3(Random.Range(-4.2f, 4.8f) , 3,9.8f), new Quaternion(1,1,1,1));


        beingHandled = false;


    }

}
