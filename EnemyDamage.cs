using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

	public int maxHealth = 100;
	int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth = maxHealth;
		
		if(currentHealth <=0)
		{
			Die();
		}
    }
	
	void Die()
	{
		Debug.Log("Enemy Died!");
		
		GetComponent<Collider2D>().enabled = false;
		this.enabled = false;
	}
}
