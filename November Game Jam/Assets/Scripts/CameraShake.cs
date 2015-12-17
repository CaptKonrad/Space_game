using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
	private Camera cam;
	private float amount = 0;

	// Use this for initialization
	void Start ()
	{
		cam = gameObject.GetComponent<Camera>();
	}
	
	public void SetCameraShake(float amt)
	{
		amount = amt;
		InvokeRepeating("Shake", 0, .02f); //recalculate the delta time for the third argument?
	}	
	
	public void SetCameraShake(float amt, float duration)
	{
		SetCameraShake(amt);
		Invoke("StopCameraShake", duration);
	}
	
	public void StopCameraShake()
	{
		amount = 0f;
		CancelInvoke("Shake");
	}
	
	private void Shake()
	{
		if(amount > 0)
		{
			Vector2 shake2 = Random.insideUnitCircle*amount;
			Vector3 shake = new Vector3(shake2.x, shake2.y, 0);//this may need to be fixxed to only use vector2s
			transform.position += shake; 
		}
	}
}
