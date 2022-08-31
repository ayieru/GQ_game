using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollision : MonoBehaviour
{
    public float posX;
    public SibaKari sk;

    static GameObject obj;

    private Vector3[] newVertices;
    private Vector3[] pos;

    private void Start()
    {
        LineRenderer line = new LineRenderer();
        line = GetComponent<LineRenderer>();
        
        line.GetPositions(pos);

        for(int i = 0; i < line.positionCount; i++)
        {
            pos[i] += new Vector3(transform.position.x, 0, transform.position.z);
        }
    }
    private void Update()
    {
        if(sk.squere)
    }
}