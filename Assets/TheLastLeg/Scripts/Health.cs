using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    private int maxHP = 5;
    public int currentHP;

    

    [SerializeField]
    private HealthUI HealthUI;

    public void DoDamage()
    {
        currentHP--;
        HealthUI.UpdateHealth(currentHP);
        if(currentHP <= 0)
        {
            Die();
        }
    }

    public void HealDamage()
    {
        currentHP++;
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        HealthUI.UpdateHealth(currentHP);
    }

    void Die()
    {
        // TODO - reset player to beginning of level or send them back to the menu.
    }
	
	void Start ()
    {
        currentHP = maxHP;
    }
	
	
	void Update () {
		
	}
}
