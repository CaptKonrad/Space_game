using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public GameObject target;
	[Range(0f, 1f)] public float followSpeed = .1f;
	public Vector2 min;
	public Vector2 max;
	
	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		Vector3 t = new Vector3(target.transform.position.x, target.transform.position.y, -10f);
		transform.position = Vector3.Lerp(transform.position, t, followSpeed);
		
		if(transform.position.x < min.x)
		{
			transform.position = new Vector3(min.x,transform.position.y, transform.position.z);
		}
		if(transform.position.x > max.x)
		{
			transform.position = new Vector3(max.x,transform.position.y, transform.position.z);
		}
		if(transform.position.y < min.y)
		{
			transform.position = new Vector3(transform.position.x, min.y, transform.position.z);
		}
		if(transform.position.y > max.y)
		{
			transform.position = new Vector3(transform.position.x, max.y, transform.position.z);
		}
	}
}
