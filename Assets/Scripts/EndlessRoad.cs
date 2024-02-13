using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {
       transform.position += new Vector3(transform.GetComponent<Renderer>().bounds.size.x * 3, 0, 0);
    }
}
