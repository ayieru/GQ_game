using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SibaKari : MonoBehaviour
{
    public Vector3[] pos;
    public int VerticsCount = 4;

    private Vector3 scale;
    private float lpos;

    private MeshFilter mf;

    private void Awake()
    {
        mf = GetComponent<MeshFilter>();
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < VerticsCount - 1; i++)
        {
            if (i == VerticsCount / 2)
            {
                pos[VerticsCount] = pos[1];
            }
            else
            {
                pos[i] = mf.mesh.vertices[i];
                pos[i] = transform.TransformPoint(pos[i]);

                pos[i + 2] = mf.mesh.vertices[i + VerticsCount];
                pos[i + 2] = transform.TransformPoint(pos[i + 2]);
            }
        }

        //unityの座標系上、入れ替えが必要
        var a = pos[2];
        pos[2] = pos[3];
        pos[3] = a;
    }
}