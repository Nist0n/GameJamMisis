using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPaper : MonoBehaviour
{
    [SerializeField] private GameObject _paper;
    private float _dropForce = 50f;
    
    public void ThrowPapers(Vector3 dropPos)
    {
        GameObject mana = Instantiate(_paper, dropPos, Quaternion.identity);
        Rigidbody manaRigidbody = mana.GetComponent<Rigidbody>();
        Vector3 randomDirection = Random.insideUnitSphere;
        manaRigidbody.AddForce(randomDirection * _dropForce, ForceMode.Impulse);
    }
}
