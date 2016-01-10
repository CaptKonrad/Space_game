using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour
{

	public void Equip(Transform p)
	{
		//set the rigidbody to kinimatic
		//parent = p;
		//transform.parent = p;
	}
	
	//Use Should Be Called Once Per Use. Not Every Frame
	public abstract void Use();
	
	//Release Should be called when it is to stop
	public abstract void Release();
}