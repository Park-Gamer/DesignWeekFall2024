using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReadyCheck : MonoBehaviour
{
    public bool p1Ready = false;
    public bool p2Ready = false;
    public GameObject ready1Off, ready1On, ready2Off, ready2On;

    private void Start()
    {
        ready1On.SetActive(false);
        ready2On.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            p1Ready = true;
            ready1Off.SetActive(false);
            ready1On.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            p2Ready = true;
            ready2Off.SetActive(false);
            ready2On.SetActive(true);
        }

        if (p1Ready && p2Ready)
        {
            SceneManager.LoadScene("MainGame");
        }
    }

}
