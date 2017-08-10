using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages the health and mana of entities
public class ResourceManagement : MonoBehaviour {

    public float MaxHealth;
    public float HealthRegen;
    private float CurrentHealth;

    public float MaxMana;
    public float ManaRegen;
    private float CurrentMana;

	// Use this for initialization
	void Start () {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
	}

    private void FixedUpdate()
    {
        if (CurrentHealth < MaxHealth)
        {
            CurrentHealth += HealthRegen * Time.fixedDeltaTime;
            if (CurrentHealth > MaxHealth)
                CurrentHealth = MaxHealth;
        }
        if (CurrentMana < MaxMana)
        {
            CurrentMana += ManaRegen * Time.fixedDeltaTime;
            if (CurrentMana > MaxMana)
                CurrentMana = MaxMana;
        }     
    }

    public float GetHeath()
    {
        return CurrentHealth;
    }

    public float GetMana()
    {
        return CurrentMana;
    }

    public void DamageHealth(float _Amount)
    {
        CurrentHealth -= _Amount;
        if(GetComponent<DropTableManager>())
        {
            GetComponent<DropTableManager>();
        }
    }

    public void HealHealth(float _Amount)
    {
        CurrentHealth += _Amount;
    }

    public void DamageMana(float _Amount)
    {
        CurrentMana -= _Amount;
    }

}
