using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public float speed;
    private void Start()
    {
        Destroy(gameObject, 2);
    }

    void Update()
    {
        transform.Translate(0, Time.deltaTime * speed,0);
    }
   
}
