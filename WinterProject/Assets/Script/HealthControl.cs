using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthControl : MonoBehaviour
{
    public Image healthBar;
    //public Text healthText;
    private float health;
    private float lerpSpeed;
    private float maxHealth;

    public void Start()
    {
        health = 100;
        maxHealth = 100;
    }

    public void SetMaxHP(float val)
    {
        health = val;
        maxHealth = val;
    }
    private void Update()
    {
        if (health > maxHealth) health = maxHealth;
        if (health < 0) health = 0;
        lerpSpeed = 3f * Time.deltaTime;
        HealthBarFiller();
    }
    void HealthBarFiller()
    {
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, health / maxHealth, lerpSpeed);
    }

    public bool ZeroDetect()
    {
        if (health == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void Damage(float damagePoints)
    {
        if (health > 0)
        {
            health -= damagePoints;
        }
    }
}