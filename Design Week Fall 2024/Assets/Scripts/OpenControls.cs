using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenControls : MonoBehaviour
{
    public GameObject rules;

    // Start is called before the first frame update
    void Start()
    {
        rules.SetActive(false);
    }

    // Update is called once per frame
    public void OpenControl()
    {
        rules.SetActive(true);
    }
}
