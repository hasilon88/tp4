using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;
    public Text healthText;
    public float maxHealth = 100f; 
    private float currentHealth; 

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider(); 
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthSlider();
        UpdateHealthText();
    }

    public void HealDamage(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthSlider();
        UpdateHealthText();
    }

    private void UpdateHealthSlider()
    {
        healthSlider.value = currentHealth;
    }
    private void UpdateHealthText()
    {
        healthText.text = Mathf.RoundToInt(currentHealth).ToString();
    }
}
