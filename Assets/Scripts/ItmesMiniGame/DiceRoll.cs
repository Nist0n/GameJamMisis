using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiceRoll : MonoBehaviour
{
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    public int ThrowDice()
    {
        int rand = Random.Range(1, 6);

        if (rand == 1)
        {
            _anim.SetTrigger("rolling1");
            return rand;
        }
        if (rand == 2)
        {
            _anim.SetTrigger("rolling2");
            return rand;
        }
        if (rand == 3)
        {
            _anim.SetTrigger("rolling3");
            return rand;
        }
        if (rand == 4)
        {
            _anim.SetTrigger("rolling4");
            return rand;
        }
        if (rand == 5)
        {
            _anim.SetTrigger("rolling5");
            return rand;
        }
        if (rand == 6)
        {
            _anim.SetTrigger("rolling6");
            return rand;
        }

        else
        {
            return 0;
        }
    }
}
