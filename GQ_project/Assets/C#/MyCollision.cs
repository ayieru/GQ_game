using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCollision : MonoBehaviour
{
    private SibaKari sk;
    private GameObject obj;

    private Vector3 pos;
    private int vc;

    private void Start()
    {
        obj = GameObject.Find("PlayerCapsule").transform.GetChild(3).gameObject;

        sk = obj.GetComponent<SibaKari>();
        vc = sk.VerticsCount;

        pos = transform.position;
    }

    private void FixedUpdate()
    {
        if(HitCheck())
        {
            Debug.Log("Hit");

            Destroy(gameObject);
        }
    }

    private bool HitCheck()
    {
        Vector2 vec1;
        Vector2 vec2;
        float[] cross_z = new float[vc];

        for (int i = 0; i < vc; i++)
        {
            vec1.x = sk.pos[i].x - pos.x;
            vec1.y = sk.pos[i].z - pos.z;

            vec2.x = sk.pos[i + 1].x - sk.pos[i].x;
            vec2.y = sk.pos[i + 1].z - sk.pos[i].z;

            cross_z[i] = vec2.x * vec1.y - vec2.y * vec1.x;
        }

        if (cross_z[0] < 0 && cross_z[1] < 0 && cross_z[2] < 0 && cross_z[3] < 0) return true;

        return false;
    }
}