using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackGroundsc : MonoBehaviour
{
    public PlPoint _plpoint;
    public bool _hitOnce=true;
    
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Box"&& _hitOnce)
        {
            _plpoint.PlayerHpDown();
            _hitOnce = false;
        }
    }
}
