using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class life_points : MonoBehaviour
{ 
    public int collisioncounter = 0;
    public GameObject cube;
    public TMPro.TextMeshProUGUI disp_texto;


    void Update()
    {
        disp_texto.text = collisioncounter.ToString();
    }

    private void OnCollisionStay(Collision collision)
    {
        //print("collision" + collision.other.name);
        if (collision.other.name == cube.name + "(Clone)"  )
        {
            collisioncounter--;
        }

        if (collisioncounter <0)
        {
            Destroy(gameObject);
            
            PauseGame();
        }

    }

    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }

}
