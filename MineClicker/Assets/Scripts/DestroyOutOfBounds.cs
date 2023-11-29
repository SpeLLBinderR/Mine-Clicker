using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float right_bound = 15;
    void Update()
    {
        if (transform.position.x > right_bound)
        {
            Destroy(gameObject);
        }
    }
}
