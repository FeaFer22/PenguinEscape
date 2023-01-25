using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
	private Vector3 velocity = Vector3.zero;
	[SerializeField] private float smoothTime = 0.75f;
    void Update() 
    {
        Vector3 pos = target.transform.position;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothTime);
    }
}
