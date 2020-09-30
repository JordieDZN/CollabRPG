using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
	}
	[Range(0f, 1f)]
	public float masterVolume = 1f;
	[Range(0f, 1f)]
	public float musicVolume = 1f;
	[Range(0f, 1f)]
	public float sfxVolume = 1f;
	public ItemCollectable collectablePrefab;
	public List<ItemCollectable> currentCollectables = new List<ItemCollectable>();

	public void spawnCollectable(Item _item, int _stack, Vector3 _location)
	{
		ItemCollectable collectable = GameManager.instance.collectablePrefab;
		collectable.item = _item;
		collectable.stack = _stack;
		Instantiate(collectable, _location, Quaternion.identity);
	}

}
