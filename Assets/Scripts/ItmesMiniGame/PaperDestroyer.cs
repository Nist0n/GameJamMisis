using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDestroyer : MonoBehaviour
{
    private bool _isSpawned = true;
    private void Update()
    {
        if(_isSpawned) StartCoroutine(DestroyPaper());
    }

    IEnumerator DestroyPaper()
    {
        Debug.Log("ff");
        _isSpawned = false;
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
