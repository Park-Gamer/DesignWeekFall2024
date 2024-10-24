using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyCheck : MonoBehaviour
{
    public bool p1Ready = false;
    public bool p2Ready = false;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            p1Ready = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            p2Ready = true;
        }

        if (p1Ready && p2Ready)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

}
