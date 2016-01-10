using UnityEngine;
using System.Collections;

public class Inventory : MonoBehaviour 
{
	//public int maxItems;
	public Item[] items;

	public bool Add(ref Item it)
	{
		for(int i = 0; i < items.Length; i++)
		{
			if(items[i] == null)
			{
				items[i] = it;
				it.gameObject.SetActive(false);
				return true;
			}
		}
		return false;
	}
	
	public Item Get(int i)
	{
		return items[i];
	}
	
	public int Size()
	{
		return items.Length;
	}
	
	public Item Remove(int it)
	{
		Item temp = items[it];
		items[it] = null;
		return temp;
	}
	
	public void Drop(int it)
	{
		Instantiate(items[it]);
		items[it] = null;
	}
}