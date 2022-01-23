using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int regenRate = 10;
    public int currentHealth;
    public float lastTimeHit;
    public Text healthText;
    void Start()
    {
        lastTimeHit = Time.time;
        currentHealth = maxHealth;
        InvokeRepeating("regainHealth", 0f, 1f);
    }

    void Update()
    {
        if(currentHealth <= 0){
            SceneManager.LoadScene(2);

        }
        else { 
            healthText.text = currentHealth.ToString();
        }
    }

    void regainHealth()
    {
        if (Time.time - lastTimeHit >= 3f && currentHealth < maxHealth )
        {
            currentHealth += regenRate;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
    }
}
