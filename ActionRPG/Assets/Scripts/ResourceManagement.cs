using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

//Manages the health and mana of entities
public class ResourceManagement : MonoBehaviour {

    public ProgressBarPositionBased HealthBar;
    public ProgressBarPositionBased ManaBar;

    public float MaxHealth;
    public float HealthRegen;
    public float CurrentHealth;

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
            HealthBar.SetPercentage(CurrentHealth / MaxHealth);
        }
        if (CurrentMana < MaxMana)
        {
            CurrentMana += ManaRegen * Time.fixedDeltaTime;
            if (CurrentMana > MaxMana)
                CurrentMana = MaxMana;
            ManaBar.SetPercentage(CurrentMana / MaxMana);
        }     
        if(DotActive)
        {
            CurrentHealth -= (DotAmount/DotTime) * Time.fixedDeltaTime;
            if(Time.time - StartTime > DotTime)
            {
                CurrentHealth = Mathf.Round(CurrentHealth);
                DotActive = false;
            }
            HealthBar.SetPercentage(CurrentHealth / MaxHealth);
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
        if(CurrentHealth <= 0)
        {
            SceneManager.LoadScene(0);
        }
        HealthBar.SetPercentage(CurrentHealth / MaxHealth);
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
        HealthBar.SetPercentage(CurrentHealth / MaxHealth);
    }

    public void HealMana(float _Amount)
    {
        CurrentMana += _Amount;
        ManaBar.SetPercentage(CurrentMana / MaxMana);
    }

    public void DamageMana(float _Amount)
    {
        CurrentMana -= _Amount;
        ManaBar.SetPercentage(CurrentMana / MaxMana);
    }

}
