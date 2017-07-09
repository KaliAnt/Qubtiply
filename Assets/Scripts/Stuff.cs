using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Stuff : MonoBehaviour
{
    public Rigidbody Body { get; private set; }

    void Awake()
    {
        Body = GetComponent<Rigidbody>();

    }
    void OnTriggerEnter(Collider enteredCollider)
    {
        if (enteredCollider.CompareTag("Kill Zone"))
        {
            Destroy(gameObject);
        }
    }
}