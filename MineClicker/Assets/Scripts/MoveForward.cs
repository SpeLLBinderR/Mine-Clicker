using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 3.0f, speedY = 1.0f;


    void Update()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Canvas").transform, false);
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        //transform.Translate(Vector3.up * speedY * Time.deltaTime);
    }
}
