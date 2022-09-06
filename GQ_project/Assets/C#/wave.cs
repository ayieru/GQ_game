using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave : MonoBehaviour
{
	private GameObject point;

	private float Grand;
	private float rand;

	private float dis;
	private float v;
	private float amp;
	private float time;

	private void Awake()
    {
		point = GameObject.Find("WavePoint");
		dis = Vector3.Distance(transform.position, point.transform.position);

		v = 4.0f;
		time = 0.0f;
		rand = Random.Range(0.0f, 10.0f);
	}

    private void FixedUpdate()
    {
		time++;
    }
}
