using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SibaKari : MonoBehaviour
{
    public Vector3[] pos;

    private Vector3 scale;

    private void Awake()
    {
        scale = transform.localScale;

        pos[0] = transform.position + new Vector3(scale.x / 2, 0, scale.z / 2);
        pos[1] = transform.position + new Vector3(scale.x / 2, 0, -scale.z / 2);
        pos[2] = transform.position + new Vector3(-scale.x / 2, 0, scale.z / 2);
        pos[3] = transform.position + new Vector3(-scale.x / 2, 0, -scale.z / 2);

    }

    private void FixedUpdate()
    {
        pos[0] = transform.position + new Vector3(scale.x / 2, 0, scale.z / 2);
        pos[1] = transform.position + new Vector3(scale.x / 2, 0, -scale.z / 2);
        pos[2] = transform.position + new Vector3(-scale.x / 2, 0, scale.z / 2);
        pos[3] = transform.position + new Vector3(-scale.x / 2, 0, -scale.z / 2);
    }
}
