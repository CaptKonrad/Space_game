using UnityEngine;
using System.Collections;

public class DamageCameraShake : MonoBehaviour
{
	public Health hp;
	
	public float amount = .8f;
	public float duration = .25f;
	
	private CameraShake camshake;
	
	// Use this for initialization
	void Start()
	{
		camshake = gameObject.GetComponent<CameraShake>();
	}
	
	// Update is called once per frame
	void Update()
	{
		if(hp.hurt && !hp.dead)
		{
			camshake.SetCameraShake(amount, duration);
		}
	}
}
