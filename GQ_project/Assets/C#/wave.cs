using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
	private GameObject point;
	private LineRenderer LR;

	private float rand;
	private Vector3 pos;

	private float dis;
	private float v;
	private float a_x;
	private float a_y;
	private float a_z;
	private float t;
	private float T;

	private void Awake()
    {
		point = GameObject.Find("WavePoint");
		LR = GetComponent<LineRenderer>();

		pos = LR.GetPosition(1);

		dis = Vector3.Distance(transform.position, point.transform.position);

		a_x = 0.05f;
		a_y = 0.05f;
		a_z = 0.08f;
		v = 0.001f;
		T = 5.0f;
		t = 0.0f;

		rand = Random.Range(0.0f, 10.0f);
	}

    private void FixedUpdate()
    {
		t++;
		t = Mathf.Round(t);

        if (t % 15 == 0)
        {
			pos.x += a_x * Mathf.Sin((Mathf.PI / T) * (t - (dis / v)));
			pos.y += a_y * Mathf.Sin((Mathf.PI / T) * (t - (dis / v)));
			pos.z += a_z * Mathf.Sin((Mathf.PI / T) * (t - (dis / v)));
			LR.SetPosition(1, pos);
		}

	}
}
