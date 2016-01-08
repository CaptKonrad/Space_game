using UnityEngine;
using System.Collections;

public abstract class Item : MonoBehaviour
{
	//private Transform parent;
	//private bool equiped;
	
	public void Equip(Transform p)
	{
		//set the rigidbody to kinimatic
		//parent = p;
		//transform.parent = p;
	}
	/*
	public Transform GetParent()
	{
		return parent;
	}
	
	public void SetParent(Transform t)
	{
		parent = t;
	}
	*/
	//Use Should Be Called Once Per Use. Not Every Frame
	public abstract void Use();
	
	//Release Should be called when it is to stop
	public abstract void Release();
}