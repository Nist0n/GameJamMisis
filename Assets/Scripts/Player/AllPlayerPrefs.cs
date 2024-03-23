using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllPlayerPrefs : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetInt("dtIsFirst", 1);
        PlayerPrefs.SetInt("hapinessScore", 1);
        PlayerPrefs.SetInt("learningScore", 1);
    }
}
