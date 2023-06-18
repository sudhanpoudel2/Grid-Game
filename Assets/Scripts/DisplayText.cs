using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public static bool isGAMEOVER;
    public GameObject gameobjectText;
    private void Awake()
    {
        isGAMEOVER = false;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGAMEOVER)
        {
            gameobjectText.SetActive(true);
        }
        
    }
}
