using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject prefab;
    public GameObject bomb;
    public Camera camera;
    private bool beingHandled = false;
    public float seconds_to_spawn = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        { 
            print("erre");
            //Reload();
            Time.timeScale = 1;
            //SceneManager.LoadScene("Sample Scene", LoadSceneMode.Single);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetMouseButtonDown(1))
        {
            //Debug.Log("Left mouse clicked");
            int layer_mask = LayerMask.GetMask("sky");
            RaycastHit hit;
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, layer_mask))
            {
                if (hit.transform.name == "sky")
                {
                    if (!beingHandled)
                    {
                        StartCoroutine(sleep_to_spawn(bomb, hit));
                    }
                    //Instantiate(bomb, hit.point+ new Vector3(0,1,0) ,  new Quaternion (1,1,1,1 ));
                    //print("My object is clicked by mouse");
                }
            }
        }
    

            if (Input.GetMouseButtonDown(0))//0 es izquierdo
            {
            Debug.Log("Left mouse click");
            int layer_mask_floor = LayerMask.GetMask("floor");
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit,60, layer_mask_floor))
                {
                if (hit.transform.name == "floor"  )
                {
                    if (!beingHandled)
                    {
                        StartCoroutine(sleep_to_spawn(prefab, hit));

                        Debug.Log("Left mouse clickasdads");
                    }
                    
                    //print("My object is clicked by mouse");
                }
            }
            }
        }


    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(6);
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        Resources.UnloadUnusedAssets();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    IEnumerator sleep_to_spawn(GameObject  prefab, RaycastHit hit)
    {
        beingHandled = true;

        //yield return new WaitForSeconds(Random.Range(0, 1f));
        yield return new WaitForSeconds(seconds_to_spawn);

        Instantiate(prefab, hit.point + new Vector3(0, 1, 0), new Quaternion(1, 1, 1, 1));

        //Instantiate(spawn, new Vector3(Random.Range(-4.2f, 4.8f), 3, 9.8f), new Quaternion(1, 1, 1, 1));


        beingHandled = false;


    }


}


 
 