using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Manages the health and mana of entities
public class ResourceManagement : MonoBehaviour {

    public float MaxHealth;
    public float HealthRegen;
    private float CurrentHealth;

    public float MaxMana;
    public float ManaRegen;
    private float CurrentMana;

    private bool DotActive = false;
    private float DotTime = 0.0f;
    private float DotAmount = 0.0f;

    private float StartTime = 0.0f;
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
        if(DotActive)
        {
            CurrentHealth -= (DotAmount/DotTime) * Time.fixedDeltaTime;
            if(Time.time - StartTime > DotTime)
            {
                CurrentHealth = Mathf.Round(CurrentHealth);
                DotActive = false;
            }
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

    public void DamageHealthOverTime(float _TotalAmount, float _Time)
    {
        DotActive = true;
        DotTime = _Time;
        DotAmount = _TotalAmount;
        StartTime = Time.time;
    }

    public void HealHealth(float _Amount)
    {
        CurrentHealth += _Amount;
    }

    public void HealMana(float _Amount)
    {
        CurrentMana += _Amount;
    }

    public void DamageMana(float _Amount)
    {
        CurrentMana -= _Amount;
    }

}
