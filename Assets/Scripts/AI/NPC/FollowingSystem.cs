using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FollowingSystem : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update()
    {
        Vector3 movement = target.position - transform.position;
        movement = new Vector3(movement.x, 0f, movement.z);

        Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, 400 * Time.deltaTime);
        if (PlayerPrefs.GetInt("dtIsFirst") == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
