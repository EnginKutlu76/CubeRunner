using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform takipEdilenKarakter;
    public float hiz = 5f;
    public Vector3 mesafe = new Vector3(-8f, 3f, 0f);

    void LateUpdate()
    {
        Vector3 hedefKonum = takipEdilenKarakter.position + mesafe;
        transform.position = Vector3.Lerp(transform.position, hedefKonum, hiz * Time.deltaTime);
    }
}
