using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : MonoBehaviour
{
    void Start()
    {
        GetComponent<Rigidbody>().velocity = -transform.forward * 10f;
    }
}
