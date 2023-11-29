using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoad : MonoBehaviour
{
   
    void Start()
    {

    }

    void Update()
    {

    }
    //OnTriggerEnter eklenir ve araba ile yola da collider eklicen ve colliderýn içindeki is trigger kutucuðu iþaretli olucak
    private void OnTriggerEnter(Collider other)
    {

       transform.position += new Vector3(transform.GetComponent<Renderer>().bounds.size.x * 3, 0, 0);

    }
}
