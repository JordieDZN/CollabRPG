using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public Slider healthSlider;
    public float MaxHealth;
    public float currenthealth;
    public GameObject DeathCanvas;

    // Start is called before the first frame update
    void Start()
    {
        currenthealth = MaxHealth;	
		DeathCanvas.SetActive(false);
    }
	
    // Update is called once per frame
    void Update()
    {
        healthSlider.value = currenthealth;
		
		if (currenthealth <= 0)
		{
			DeathCanvas.SetActive(true);
		}
    }
}
