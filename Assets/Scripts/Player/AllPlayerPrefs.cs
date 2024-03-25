using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerPrefs : MonoBehaviour
{
    private Music _music;
    void Start()
    {
        if(FindObjectOfType<Music>() != null) Destroy(FindObjectOfType<Music>().gameObject);
        PlayerPrefs.SetInt("dtIsFirst", 1);
        PlayerPrefs.SetInt("hapinessScore", 1);
        PlayerPrefs.SetInt("learningScore", 1);
        PlayerPrefs.SetInt("cloak", 8);
        PlayerPrefs.SetInt("currentLoc", 0);
    }
}
