using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
	public float damage;
	public PlayerHealth health;
	
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Z))
		{
			TakeDamage();
		}
	}
	
	void TakeDamage()
	{
		health.currenthealth -=damage;
	}
}













