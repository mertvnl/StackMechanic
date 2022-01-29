using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stacker : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Stackable s = other.GetComponent<Stackable>();

        if (s != null)
        {
            Debug.Log(s, s.gameObject);
        }
    }
}
